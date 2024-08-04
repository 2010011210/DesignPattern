namespace DesignPattern.Model.ChainOfResponsibility
{
    public class ApplyContent
    {
        /// <summary>
        /// 请假多长事件
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// 请假原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 请假结果
        /// </summary>
        public bool Result { get; set; }  
    }
}
