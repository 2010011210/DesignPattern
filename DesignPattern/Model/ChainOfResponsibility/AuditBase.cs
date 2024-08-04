namespace DesignPattern.Model.ChainOfResponsibility
{
    public abstract class AuditBase
    {
        public string Name { get; set; }
        public abstract ApplyContent Audit(ApplyContent applyContent);

        private AuditBase HighLeverAudit { get; set; }

        public void SetAuditNext(AuditBase auditor) 
        {
            HighLeverAudit = auditor;
        }

        protected ApplyContent AuditNext(ApplyContent applyContent) 
        {
            if (HighLeverAudit != null)
            {
                return HighLeverAudit.Audit(applyContent);
            }
            else 
            {
                applyContent.Result = false;
                return applyContent;
            }
            
        }



    }
}
