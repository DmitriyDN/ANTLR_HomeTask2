
namespace ANTLR_Hometask2
{
    public class Calculator : CalculatorBaseVisitor<int>
    {
        public override int VisitAtom(CalculatorParser.AtomContext context)
         {
            if (context.children.Count == 1)
            {
                return int.Parse(context.INT().GetText());
            }
                return VisitExpr(context.expr());
        }

        public override int VisitMultExpression(CalculatorParser.MultExpressionContext context)
        {
            int left = Visit(context.atom(0));
            if (context.atom(1) != null)
            {
                int right = Visit(context.atom(1));

                switch (context.children[1].ToString())
                {
                    case "+":
                        return left + right;
                    case "-":
                        return left - right;
                    case "*":
                        return left * right;
                    case "/":
                        return left / right;
                    default:
                        return 0;
                } 

            }
            return left;
        }

        public override int VisitExpr(CalculatorParser.ExprContext context)
        {
            int result = 0;
            int index = 0;

            for (int i = 0; i < context.children.Count; i+=3)
            {
                int left = 0;
                int right = 0;
                string operation = "";
                if (i > 0)
                {
                    left = result;
                    right = Visit(context.multExpression(index));
                    index+=1;
                    if (i % 2 == 0)
                    {
                        operation = context.children[i - 1].ToString();
                        i--;
                    }
                    else
                    {
                        operation = context.children[i].ToString();   
                    }
                }
                else
                {
                    left = VisitMultExpression(context.multExpression(0));
                    right = (context.multExpression(1) != null) ? VisitMultExpression(context.multExpression(1)) : 0;
                    operation = (context.children.Count > 1) ? context.children[i + 1].ToString() : "+";
                    index += 2;
                }

                switch (operation)
                {
                    case "+":
                        result = left + right;
                        break;
                    case "-":
                        result = left - right;
                        break;
                    case "*":
                        result = left * right;
                        break;
                    case "/":
                        result = left / right;
                        break;
                    default:
                        return 0;
                }   
            }

            return result;
        }
    }
}
