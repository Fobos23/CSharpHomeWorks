using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5.Task4
{
    public class ExamResultPrinter
    {
        private List<Disciple> _disciples;

        public ExamResultPrinter()
        {
            var dbDecorator = new DbDecorator();
            _disciples = dbDecorator.Disciples;
        }

        public string GetText()
        {
            if (_disciples.Count < 10 || _disciples.Count > 100)
                return "Количество учеников не соответствует требуемому количеству";

            var title = $"Количество учеников, сдаваших экзамен {_disciples.Count}.\nТоп худших:";

            var orderedDisciples= _disciples.OrderBy(disciple => disciple.Ratings.Average);
            var sb = new StringBuilder();
            sb.AppendLine(title);
            foreach (var disciple in orderedDisciples)
                if (disciple.Ratings.Average < 3.5)
                    sb.AppendLine(disciple.ToString());

            return sb.ToString();
        }
    }
}