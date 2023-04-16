grammar Lattice;

options {
    language=CSharp;
}

/*
 * Parser Rules
 */
 
start :(statement| funcdef)*;
statement 
    : vardecl 
    | varassignorgraphmanip
    | printstatement
    | ifblock
    |whileblock
    |funccall SEMICOLON /*depends on the role we want functions/methods to have */
    | returnstatement
    ;
funcdef : OP_DEF type ID LEFT_PAREN (listargs)? RIGHT_PAREN LEFT_BRACE statement*  RIGHT_BRACE; 
returnstatement :  OP_RETURN assignval SEMICOLON;
listargs : arg taillistarg; 
arg : type ID; 
taillistarg : (COMMA arg)*; 
printstatement: OP_PRINT (ID | STRING) SEMICOLON; 
vardecl     : type ID vardecltail; 
vardecltail : tailvarassignorgraphmanip | SEMICOLON; 
type        
    : TYPE_STRING
    | TYPE_FLOAT
    | TYPE_BOOL
    | TYPE_INT
    | TYPE_GRAPH
    ; 
varassignorgraphmanip : ID tailvarassignorgraphmanip; 
tailvarassignorgraphmanip : tailvarassign | tailgraphmanip; 
tailvarassign : OP_ASSIGN assignval SEMICOLON; 
assignval : STRING | number | expr | boolval; 
boolval :KEYWORD_TRUE | KEYWORD_FALSE; 
tailgraphmanip : LEFT_BRACE graphop? RIGHT_BRACE;
graphop  
    : addrel
    | addclone
    | addref
    ;
addref : OP_REF ID SEMICOLON; 
addclone : OP_CLONE ID SEMICOLON; 
addrel : ID OP_REL_LEFT number COMMA STRING OP_REL_RIGHT ID; 
expr : OP_SUB expr     # UMINUS 
   | expr mulop expr # MULOPGRP
   | expr addop expr # ADDOPGRP
   | LEFT_PAREN expr RIGHT_PAREN   # PARENGRP
   |  number # DOUBLE
   | ID # IDCASE
   | funccall #FUNCTIONCALL
   | KEYWORD_FMAP ID ID # FUNCTIONMAPPING
   ;
number : INTEGER | FLOAT_LIT; 
addop : OP_ADD | OP_SUB ; 
mulop : OP_MULT | OP_DIV | OP_REM ;
ifblock : KEYWORD_IF LEFT_PAREN boolexpr RIGHT_PAREN LEFT_BRACE statement* RIGHT_BRACE (KEYWORD_ELSE LEFT_BRACE statement* RIGHT_BRACE)?; 
boolexpr : OP_B_NOT boolexpr #NOT 
            | boolexpr boolop boolexpr #BOOLOP
            | assignval compop assignval #COMPGRP
            | LEFT_PAREN boolexpr RIGHT_PAREN # PARENGRPBOOL
            | ID #IDBOOL
            | funccall #FUNCCALL
            |boolval #BOOLVAL
            ; 
boolop :OP_B_AND | OP_B_OR; 
compop :  OP_B_EQ | OP_B_NEQ | OP_GRT; 
funccall : ID LEFT_PAREN (listparams)? RIGHT_PAREN; 
whileblock : KEYWORD_WHILE LEFT_PAREN boolexpr RIGHT_PAREN LEFT_BRACE statement* RIGHT_BRACE; /*add break and continue ? */
listparams : param taillistparams;
param : ID;
taillistparams : (COMMA param)*;
/*
 * Lexer Rules
 */
 
fragment NEWLINE    : '\r\n' | '\n';
fragment CHARACTER  : ~[ \t\r\n];
fragment WS         : ' ' | '\t';
fragment LETTER     : [a-zA-Z];
fragment DIGIT      : [0-9];
fragment NZ_DIGIT   : [1-9];
fragment ALPHANUM   : [a-zA-Z0-9];
fragment HEX_LIT    : [0-9a-fA-F];
fragment DQ_STRING  : '"' (CHARACTER | WS)*? '"';
fragment SQ_STRING  : '\'' (CHARACTER | WS)*? '\'';
 
WHITESPACE          : (WS | NEWLINE)+ -> skip;
SINGLELINE_COMMENT  : '//' (CHARACTER | WS)* NEWLINE -> skip;
MULTILINE_COMMENT   : '/*' .*? '*/' -> skip;

STRING              : DQ_STRING | SQ_STRING;
FLOAT_LIT           : '-'? NATURAL_NUMBER '.' DIGIT+;
INTEGER             :  NATURAL_NUMBER;
NATURAL_NUMBER      : ('0' | NZ_DIGIT DIGIT*);
 
SEMICOLON : ';';
LEFT_BRACE : '{';
RIGHT_BRACE : '}';
LEFT_PAREN : '(';
RIGHT_PAREN : ')';
COMMA : ',';

OP_ASSIGN : '=';

OP_B_EQ : '==';
OP_B_NEQ : '!=';
OP_B_OR : '||';
OP_B_AND : '&&';
OP_B_NOT : '!';

OP_ADD : '+';
OP_SUB : '-';
OP_MULT : '*';
OP_DIV : '/';
OP_REM : '%';
OP_GRT : '<';
OP_REF : 'ref';
OP_CLONE : 'clone';
OP_RETURN : 'return';
OP_PRINT : 'print';
OP_DEF : 'def';
TYPE_INT : 'int';
TYPE_FLOAT : 'float';
TYPE_STRING : 'str';
TYPE_BOOL : 'bool';
TYPE_GRAPH : 'graph';
TYPE_RELATIONSHIP : 'rel';

KEYWORD_FMAP : 'fmap';
KEYWORD_IF : 'if';
KEYWORD_ELSE : 'else';
KEYWORD_WHILE : 'while';
KEYWORD_TRUE : 'true';
KEYWORD_FALSE : 'false';

OP_REL_LEFT:'|-';
OP_REL_RIGHT:'->';

ID : ('a'..'z'|'A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'_');