//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/balazsagardi/Non-Sync Docs/repos/LatticeCSharp/Lattice/Lattice.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="LatticeParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface ILatticeListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] LatticeParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] LatticeParser.StartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] LatticeParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] LatticeParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.funcstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncstatement([NotNull] LatticeParser.FuncstatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.funcstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncstatement([NotNull] LatticeParser.FuncstatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.funcdef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncdef([NotNull] LatticeParser.FuncdefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.funcdef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncdef([NotNull] LatticeParser.FuncdefContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.funcdefheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncdefheader([NotNull] LatticeParser.FuncdefheaderContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.funcdefheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncdefheader([NotNull] LatticeParser.FuncdefheaderContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.returnstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnstatement([NotNull] LatticeParser.ReturnstatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.returnstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnstatement([NotNull] LatticeParser.ReturnstatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.listargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterListargs([NotNull] LatticeParser.ListargsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.listargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitListargs([NotNull] LatticeParser.ListargsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.arg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArg([NotNull] LatticeParser.ArgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.arg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArg([NotNull] LatticeParser.ArgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.taillistarg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTaillistarg([NotNull] LatticeParser.TaillistargContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.taillistarg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTaillistarg([NotNull] LatticeParser.TaillistargContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.printstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintstatement([NotNull] LatticeParser.PrintstatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.printstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintstatement([NotNull] LatticeParser.PrintstatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.vardecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVardecl([NotNull] LatticeParser.VardeclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.vardecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVardecl([NotNull] LatticeParser.VardeclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.vardecltail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVardecltail([NotNull] LatticeParser.VardecltailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.vardecltail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVardecltail([NotNull] LatticeParser.VardecltailContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] LatticeParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] LatticeParser.TypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.varassignorgraphmaniporaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarassignorgraphmaniporaddrel([NotNull] LatticeParser.VarassignorgraphmaniporaddrelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.varassignorgraphmaniporaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarassignorgraphmaniporaddrel([NotNull] LatticeParser.VarassignorgraphmaniporaddrelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.tailvarassignorgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailvarassignorgraphmanip([NotNull] LatticeParser.TailvarassignorgraphmanipContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.tailvarassignorgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailvarassignorgraphmanip([NotNull] LatticeParser.TailvarassignorgraphmanipContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.tailvarassign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailvarassign([NotNull] LatticeParser.TailvarassignContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.tailvarassign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailvarassign([NotNull] LatticeParser.TailvarassignContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.assignval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignval([NotNull] LatticeParser.AssignvalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.assignval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignval([NotNull] LatticeParser.AssignvalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.boolval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolval([NotNull] LatticeParser.BoolvalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.boolval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolval([NotNull] LatticeParser.BoolvalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.tailgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailgraphmanip([NotNull] LatticeParser.TailgraphmanipContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.tailgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailgraphmanip([NotNull] LatticeParser.TailgraphmanipContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.addref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddref([NotNull] LatticeParser.AddrefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.addref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddref([NotNull] LatticeParser.AddrefContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.addclone"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddclone([NotNull] LatticeParser.AddcloneContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.addclone"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddclone([NotNull] LatticeParser.AddcloneContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.tailaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailaddrel([NotNull] LatticeParser.TailaddrelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.tailaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailaddrel([NotNull] LatticeParser.TailaddrelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.outmostexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOutmostexpr([NotNull] LatticeParser.OutmostexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.outmostexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOutmostexpr([NotNull] LatticeParser.OutmostexprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>UMINUS</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUMINUS([NotNull] LatticeParser.UMINUSContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UMINUS</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUMINUS([NotNull] LatticeParser.UMINUSContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IDCASE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIDCASE([NotNull] LatticeParser.IDCASEContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IDCASE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIDCASE([NotNull] LatticeParser.IDCASEContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>STRINGEXPR</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSTRINGEXPR([NotNull] LatticeParser.STRINGEXPRContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>STRINGEXPR</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSTRINGEXPR([NotNull] LatticeParser.STRINGEXPRContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FUNCTIONCALL</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFUNCTIONCALL([NotNull] LatticeParser.FUNCTIONCALLContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FUNCTIONCALL</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFUNCTIONCALL([NotNull] LatticeParser.FUNCTIONCALLContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>PARENGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPARENGRP([NotNull] LatticeParser.PARENGRPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>PARENGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPARENGRP([NotNull] LatticeParser.PARENGRPContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>DOUBLE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDOUBLE([NotNull] LatticeParser.DOUBLEContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>DOUBLE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDOUBLE([NotNull] LatticeParser.DOUBLEContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>MULOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMULOPGRP([NotNull] LatticeParser.MULOPGRPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>MULOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMULOPGRP([NotNull] LatticeParser.MULOPGRPContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FUNCTIONMAPPING</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFUNCTIONMAPPING([NotNull] LatticeParser.FUNCTIONMAPPINGContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FUNCTIONMAPPING</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFUNCTIONMAPPING([NotNull] LatticeParser.FUNCTIONMAPPINGContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ADDOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterADDOPGRP([NotNull] LatticeParser.ADDOPGRPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ADDOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitADDOPGRP([NotNull] LatticeParser.ADDOPGRPContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] LatticeParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] LatticeParser.NumberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.addop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddop([NotNull] LatticeParser.AddopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.addop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddop([NotNull] LatticeParser.AddopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.mulop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulop([NotNull] LatticeParser.MulopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.mulop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulop([NotNull] LatticeParser.MulopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.ifblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfblock([NotNull] LatticeParser.IfblockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.ifblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfblock([NotNull] LatticeParser.IfblockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.ifheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfheader([NotNull] LatticeParser.IfheaderContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.ifheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfheader([NotNull] LatticeParser.IfheaderContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.elseblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseblock([NotNull] LatticeParser.ElseblockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.elseblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseblock([NotNull] LatticeParser.ElseblockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.outmostboolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOutmostboolexpr([NotNull] LatticeParser.OutmostboolexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.outmostboolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOutmostboolexpr([NotNull] LatticeParser.OutmostboolexprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BOOLVAL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBOOLVAL([NotNull] LatticeParser.BOOLVALContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BOOLVAL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBOOLVAL([NotNull] LatticeParser.BOOLVALContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BOOLEXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBOOLEXPRCOMPGRP([NotNull] LatticeParser.BOOLEXPRCOMPGRPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BOOLEXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBOOLEXPRCOMPGRP([NotNull] LatticeParser.BOOLEXPRCOMPGRPContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>NOT</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNOT([NotNull] LatticeParser.NOTContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>NOT</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNOT([NotNull] LatticeParser.NOTContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>PARENGRPBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPARENGRPBOOL([NotNull] LatticeParser.PARENGRPBOOLContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>PARENGRPBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPARENGRPBOOL([NotNull] LatticeParser.PARENGRPBOOLContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BOOLOP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBOOLOP([NotNull] LatticeParser.BOOLOPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BOOLOP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBOOLOP([NotNull] LatticeParser.BOOLOPContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>EXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEXPRCOMPGRP([NotNull] LatticeParser.EXPRCOMPGRPContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>EXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEXPRCOMPGRP([NotNull] LatticeParser.EXPRCOMPGRPContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IDBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIDBOOL([NotNull] LatticeParser.IDBOOLContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IDBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIDBOOL([NotNull] LatticeParser.IDBOOLContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FUNCCALL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFUNCCALL([NotNull] LatticeParser.FUNCCALLContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FUNCCALL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFUNCCALL([NotNull] LatticeParser.FUNCCALLContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.boolop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolop([NotNull] LatticeParser.BoolopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.boolop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolop([NotNull] LatticeParser.BoolopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.compop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompop([NotNull] LatticeParser.CompopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.compop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompop([NotNull] LatticeParser.CompopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.funccall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunccall([NotNull] LatticeParser.FunccallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.funccall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunccall([NotNull] LatticeParser.FunccallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.whileblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileblock([NotNull] LatticeParser.WhileblockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.whileblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileblock([NotNull] LatticeParser.WhileblockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.whileblockheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileblockheader([NotNull] LatticeParser.WhileblockheaderContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.whileblockheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileblockheader([NotNull] LatticeParser.WhileblockheaderContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.listparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterListparams([NotNull] LatticeParser.ListparamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.listparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitListparams([NotNull] LatticeParser.ListparamsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam([NotNull] LatticeParser.ParamContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam([NotNull] LatticeParser.ParamContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LatticeParser.taillistparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTaillistparams([NotNull] LatticeParser.TaillistparamsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LatticeParser.taillistparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTaillistparams([NotNull] LatticeParser.TaillistparamsContext context);
}
