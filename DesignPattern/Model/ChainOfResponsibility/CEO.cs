namespace DesignPattern.Model.ChainOfResponsibility
{
    public class CEO : AuditBase
    {
        public CEO(string name) 
        {
            this.Name= name;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="applyContent"></param>
        /// <returns></returns>
        public override ApplyContent Audit(ApplyContent applyContent)
        {
            if (applyContent.Hours < 240)
            {
                Console.WriteLine($"{this.GetType().Name}申请通过");
                applyContent.Result = true;

                return applyContent;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}时间太长，拒绝");
                return base.AuditNext(applyContent);
            }
        }
    }
}
