namespace Task13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> keyValuePairs = new Dictionary<string, long>();
            // Сколько слов выводить
            int outputCountWord = 10;

            string text;

            // читаем весь файл в строку текста
            try
            {
                text = File.ReadAllText("D:\\Андрей\\Программирование\\C#\\SF\\Task13.6.2\\Task13.6.2\\Text1.txt");
            }
            catch 
            {
                Console.Write("Ошибка чтения файла");   
                return;
            }
            // убираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Подсчитываем повторы слов в тексте
            foreach (string word in words)
            {
                if (keyValuePairs.ContainsKey(word))
                    keyValuePairs[word]++;
                else
                    keyValuePairs.Add(word, 1);
            }

            // Сортируем по значению
            var myList = keyValuePairs.ToList();
            myList.Sort((x, y) => x.Value.CompareTo(y.Value));
            myList.Reverse();

            // Проверка на случай когда количество выводимых слов больше самих слов
            if(outputCountWord > myList.Count) outputCountWord = myList.Count;

            // выводим в консоль самые частые слова
            for (int i = 0; i < outputCountWord; i++)
            {
                Console.WriteLine($"Слово \"{myList[i].Key}\" встречается {myList[i].Value} раз");
            }

            Console.ReadLine();
        }
    }
}