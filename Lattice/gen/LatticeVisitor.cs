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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="LatticeParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface ILatticeVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] LatticeParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] LatticeParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.funcstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncstatement([NotNull] LatticeParser.FuncstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.funcdef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncdef([NotNull] LatticeParser.FuncdefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.funcdefheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncdefheader([NotNull] LatticeParser.FuncdefheaderContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.returnstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnstatement([NotNull] LatticeParser.ReturnstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.listargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListargs([NotNull] LatticeParser.ListargsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.arg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArg([NotNull] LatticeParser.ArgContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.taillistarg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTaillistarg([NotNull] LatticeParser.TaillistargContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.printstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintstatement([NotNull] LatticeParser.PrintstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.fmapstatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFmapstatement([NotNull] LatticeParser.FmapstatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.vardecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVardecl([NotNull] LatticeParser.VardeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.vardecltail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVardecltail([NotNull] LatticeParser.VardecltailContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] LatticeParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.varassignorgraphmaniporaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarassignorgraphmaniporaddrel([NotNull] LatticeParser.VarassignorgraphmaniporaddrelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.tailvarassignorgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTailvarassignorgraphmanip([NotNull] LatticeParser.TailvarassignorgraphmanipContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.tailvarassign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTailvarassign([NotNull] LatticeParser.TailvarassignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.assignval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignval([NotNull] LatticeParser.AssignvalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.boolval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolval([NotNull] LatticeParser.BoolvalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.tailgraphmanip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTailgraphmanip([NotNull] LatticeParser.TailgraphmanipContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.addref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddref([NotNull] LatticeParser.AddrefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.addclone"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddclone([NotNull] LatticeParser.AddcloneContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.tailaddrel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTailaddrel([NotNull] LatticeParser.TailaddrelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.outmostexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOutmostexpr([NotNull] LatticeParser.OutmostexprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UMINUS</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUMINUS([NotNull] LatticeParser.UMINUSContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IDCASE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIDCASE([NotNull] LatticeParser.IDCASEContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>STRINGEXPR</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSTRINGEXPR([NotNull] LatticeParser.STRINGEXPRContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FUNCTIONCALL</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFUNCTIONCALL([NotNull] LatticeParser.FUNCTIONCALLContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PARENGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPARENGRP([NotNull] LatticeParser.PARENGRPContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DOUBLE</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDOUBLE([NotNull] LatticeParser.DOUBLEContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>MULOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMULOPGRP([NotNull] LatticeParser.MULOPGRPContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ADDOPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitADDOPGRP([NotNull] LatticeParser.ADDOPGRPContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] LatticeParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.addop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddop([NotNull] LatticeParser.AddopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.mulop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulop([NotNull] LatticeParser.MulopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.ifblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfblock([NotNull] LatticeParser.IfblockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.ifheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfheader([NotNull] LatticeParser.IfheaderContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.elseblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseblock([NotNull] LatticeParser.ElseblockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.outmostboolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOutmostboolexpr([NotNull] LatticeParser.OutmostboolexprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BOOLVAL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBOOLVAL([NotNull] LatticeParser.BOOLVALContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BOOLEXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBOOLEXPRCOMPGRP([NotNull] LatticeParser.BOOLEXPRCOMPGRPContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NOT</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNOT([NotNull] LatticeParser.NOTContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PARENGRPBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPARENGRPBOOL([NotNull] LatticeParser.PARENGRPBOOLContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BOOLOP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBOOLOP([NotNull] LatticeParser.BOOLOPContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>EXPRCOMPGRP</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEXPRCOMPGRP([NotNull] LatticeParser.EXPRCOMPGRPContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IDBOOL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIDBOOL([NotNull] LatticeParser.IDBOOLContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FUNCCALL</c>
	/// labeled alternative in <see cref="LatticeParser.boolexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFUNCCALL([NotNull] LatticeParser.FUNCCALLContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.boolop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolop([NotNull] LatticeParser.BoolopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.compop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompop([NotNull] LatticeParser.CompopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.funccall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunccall([NotNull] LatticeParser.FunccallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.whileblock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileblock([NotNull] LatticeParser.WhileblockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.whileblockheader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileblockheader([NotNull] LatticeParser.WhileblockheaderContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.listparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListparams([NotNull] LatticeParser.ListparamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] LatticeParser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LatticeParser.taillistparams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTaillistparams([NotNull] LatticeParser.TaillistparamsContext context);
}
