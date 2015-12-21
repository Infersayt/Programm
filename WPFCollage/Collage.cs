using System.Drawing;

namespace WPFCollage
{
    /// <summary>
    /// Коллаж (контекст для применения паттерна Cтратегия) реализован как Одиночка
    /// Доступ к текущему единственному экземпляру коллажа будет происходить через свойство Instance
    /// </summary>
    public class Collage
    {
        // Единственный экземпляр контекста описываем как статическую переменную,
        // которая будеи инициализирована при первом обращении:
        private static Collage _instance;
        public static Collage Instance
        {
            get
            {
                // Если контекст ещё не создан, создаём:
                if (_instance == null)
                    _instance = new Collage();
                return _instance;
            }
        }
        // Конструктор защищён, чтобы нельзя было явно создавать экземпляры коллажа,
        // Все обращения к коллажу - через Instance (паттерн Одиночка)
        protected Collage()
        {
            // Стратегия по умолчанию - построение коллажа из четрыёх картинок:
            Strategy = new BuildStrategy4();
        }

        // Свойство для назначения стратегии:
        public IBuildStrategy Strategy { get; set; }
       
        // При загрузке из файла стратегия назначается по количеству картинок в коллаже
        public int PictureCount
        {
            get
            {
                return Strategy.GetPictureCount();
            }
            set
            {
                switch (value)
                {
                    case 4:
                        Strategy = new BuildStrategy4();
                        break;
                    case 6:
                        Strategy = new BuildStrategy6();
                        break;
                    case 8:
                        Strategy = new BuildStrategy8();
                        break;
                }
            }
        }

        // Назначаемый путь к 
        public string PicturesPath { get; set; }

        // Картинка содержащая результат построения коллажа
        public Image Result { get; set; }

        // Название коллажа:
        public string Name { get; set; }

        // Описание коллажа:
        public string Description { get; set; }

        // Метод контекста, вызывающий метод построения коллажа с использованием назначенной Стратегии:
        public void BuilCollage()
        {            
            Result = Strategy.Build(PicturesPath);
        }

    }
}
