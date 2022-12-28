namespace Magecase.DataEntities
{
    public struct QuestionDataEntities
    {
        public string Category { get; set; }
        public string Question { get; set; }
        public string[] Choices { get; set; }
        public string Answer { get; set; }
    }
}