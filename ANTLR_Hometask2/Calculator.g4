grammar Calculator;

/*
 * Parser Rules
 */

calc	:	statement+;

statement
	:	expr;
	
expr	:	multExpression ('+' multExpression |'-' multExpression)*;

multExpression
	:	a1=atom ('*' a2=atom | '/' a2=atom)*;
	
atom	:	INT | '(' expr ')';

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

INT :	'0'..'9'+;

WS
	:	' ' -> channel(HIDDEN)
	;
