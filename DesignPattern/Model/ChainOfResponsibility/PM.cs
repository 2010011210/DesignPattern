namespace DesignPattern.Model.ChainOfResponsibility
{
    public class PM : AuditBase
    {
        public PM(string name)
        {
            this.Name = name;
        }
        public override ApplyContent Audit(ApplyContent applyContent)
        {
            if (applyContent.Hours < 8)
            {
                Console.WriteLine($"{this.GetType().Name}申请通过");
                applyContent.Result = true;
                
                return applyContent;
            }
            else 
            {
                Console.WriteLine($"{this.GetType().Name}没有权限审批，请求上级");
                return base.AuditNext(applyContent);
            }
        }
    }
}
