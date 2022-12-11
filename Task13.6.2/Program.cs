namespace Task13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> wordsCount = new Dictionary<string, long>();
            // Сколько слов выводить
            int outputCountWord = 10;

            string fileText;

            // читаем весь файл в строку текста
            try
            {
                fileText = File.ReadAllText("D:\\Андрей\\Программирование\\C#\\SF\\Task13.6.2\\Task13.6.2\\Text1.txt");
            }
            catch 
            {
                Console.Write("Ошибка чтения файла");   
                return;
            }
            // убираем из текста знаки пунктуации
            var noPunctuationText = new string(fileText.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Подсчитываем повторы слов в тексте
            foreach (string word in words)
            {
                if (wordsCount.ContainsKey(word))
                    wordsCount[word]++;
                else
                    wordsCount.Add(word, 1);
            }

            // Сортируем по значению
            var listForSort = wordsCount.ToList();
            listForSort.Sort((x, y) => x.Value.CompareTo(y.Value));
            listForSort.Reverse();

            // Проверка на случай когда количество выводимых слов больше самих слов
            if(outputCountWord > listForSort.Count) outputCountWord = listForSort.Count;

            // выводим в консоль самые частые слова
            for (int i = 0; i < outputCountWord; i++)
            {
                Console.WriteLine($"Слово \"{listForSort[i].Key}\" встречается {listForSort[i].Value} раз");
            }

            Console.ReadLine();
        }
    }
}