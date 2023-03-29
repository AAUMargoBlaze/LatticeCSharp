grammar Lattice;

options {
    language=CSharp;
}

/*
 * Parser Rules
 */
 
start       : statements ;
statements  : statement statements*;
statement 
    : vardecl 
    | graphdecl
    | varassignorgraphmanip
    | printstatement
    ;
printstatement: OP_PRINT (ID | STRING) SEMICOLON;
vardecl     : type ID vardecltail;
vardecltail : tailvarassign | SEMICOLON;
graphdecl   : TYPE_GRAPH ID tailgraphmanip;
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
assignval : INTEGER | STRING;
tailgraphmanip : LEFT_BRACE listgraphop RIGHT_BRACE;
listgraphop : graphop listgraphop;
graphop 
    : addrel
    | addclone
    | addref
    ;
addref : OP_REF ID SEMICOLON;
addclone : OP_CLONE ID SEMICOLON;
addrel : ID OP_REL_LEFT INTEGER COMMA STRING OP_REL_RIGHT ID;

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
INTEGER             : '-'? NATURAL_NUMBER;
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

OP_PRINT : 'print';

TYPE_INT : 'int';
TYPE_FLOAT : 'float';
TYPE_STRING : 'str';
TYPE_BOOL : 'bool';
TYPE_GRAPH : 'graph';
TYPE_RELATIONSHIP : 'rel';

KEYWORD_TRUE : 'true';
KEYWORD_FALSE : 'false';

OP_REL_LEFT:'|-';
OP_REL_RIGHT:'->';

ID          : LETTER+;
