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
    | varassignorgraphmaniporaddrel
    | printstatement
    | ifblock
    |whileblock
    |funccall SEMICOLON /*depends on the role we want functions/methods to have */
    | addclone
    | fmapstatement
    | addref
    ;
funcstatement : statement | returnstatement;
funcdef : funcdefheader LEFT_BRACE funcstatement* RIGHT_BRACE; 
funcdefheader: KEYWORD_DEF type ID LEFT_PAREN (listargs)? RIGHT_PAREN;
returnstatement :  OP_RETURN (outmostexpr | outmostboolexpr) SEMICOLON;
listargs : arg taillistarg; 
arg : type ID; 
taillistarg : (COMMA arg)*; 
printstatement: OP_PRINT (ID | STRING) SEMICOLON; 
fmapstatement:  KEYWORD_FMAP ID ID SEMICOLON; 
vardecl     : type ID vardecltail; 
vardecltail : tailvarassignorgraphmanip | SEMICOLON; 
type        
    : TYPE_STRING
    | TYPE_FLOAT
    | TYPE_BOOL
    | TYPE_INT
    | TYPE_GRAPH
    ; 
varassignorgraphmaniporaddrel : ID (tailvarassignorgraphmanip | tailaddrel); 
tailvarassignorgraphmanip : tailvarassign | tailgraphmanip; 
tailvarassign : OP_ASSIGN assignval SEMICOLON; 
assignval : outmostexpr | outmostboolexpr; 
boolval :KEYWORD_TRUE | KEYWORD_FALSE; 
tailgraphmanip : LEFT_BRACE statement* RIGHT_BRACE;
addref : OP_REF ID SEMICOLON; 
addclone : OP_CLONE ID (KEYWORD_AS ID)? SEMICOLON; 
tailaddrel : OP_REL_LEFT number COMMA STRING OP_REL_RIGHT ID; 
outmostexpr: expr;
expr : OP_SUB expr     # UMINUS 
   | expr mulop expr # MULOPGRP
   | expr addop expr # ADDOPGRP
   | LEFT_PAREN expr RIGHT_PAREN   # PARENGRP
   |  number # DOUBLE
   | ID # IDCASE
   | funccall #FUNCTIONCALL
   | STRING #STRINGEXPR
   ;
number : INTEGER | FLOAT_LIT; 
addop : OP_ADD | OP_SUB ; 
mulop : OP_MULT | OP_DIV | OP_REM ;
ifblock : ifheader LEFT_BRACE statement* RIGHT_BRACE (elseblock)?;
ifheader: KEYWORD_IF LEFT_PAREN outmostboolexpr RIGHT_PAREN;
elseblock: KEYWORD_ELSE LEFT_BRACE statement* RIGHT_BRACE;
outmostboolexpr : boolexpr; 
boolexpr : OP_B_NOT boolexpr #NOT 
            | boolexpr boolop boolexpr #BOOLOP
            | boolexpr compop boolexpr #BOOLEXPRCOMPGRP
            | expr compop expr #EXPRCOMPGRP
            | LEFT_PAREN boolexpr RIGHT_PAREN # PARENGRPBOOL
            | ID #IDBOOL
            | funccall #FUNCCALL
            |boolval #BOOLVAL
            ; 
boolop :OP_B_AND | OP_B_OR; 
compop :  OP_B_EQ | OP_B_NEQ | OP_GRT; 
funccall : ID LEFT_PAREN (listparams)? RIGHT_PAREN; 
whileblock : whileblockheader LEFT_BRACE statement* RIGHT_BRACE; /*add break and continue ? */
whileblockheader: KEYWORD_WHILE LEFT_PAREN outmostboolexpr RIGHT_PAREN;
listparams : param taillistparams;
param : (outmostboolexpr | outmostexpr);
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

PYTHON   : '<PYTHON>' .*? '</PYTHON>' -> channel(99);
SNEK   : '🐍' .*? '🦅' -> channel(99);

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
KEYWORD_DEF : 'def';
TYPE_INT : 'int';
TYPE_FLOAT : 'float';
TYPE_STRING : 'str';
TYPE_BOOL : 'bool';
TYPE_GRAPH : 'graph';
TYPE_RELATIONSHIP : 'rel';

KEYWORD_FMAP : 'fmap';
KEYWORD_AS : 'as';
KEYWORD_IF : 'if';
KEYWORD_ELSE : 'else';
KEYWORD_WHILE : 'while';
KEYWORD_TRUE : 'true';
KEYWORD_FALSE : 'false';

OP_REL_LEFT:'|-';
OP_REL_RIGHT:'->';

ID : (LETTER | '_') (LETTER | DIGIT | '_')* ;
