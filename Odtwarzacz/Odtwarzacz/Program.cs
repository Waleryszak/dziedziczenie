namespace Odtwarzacz
{
    abstract class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Song(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }

        public virtual void Play()
        {
            Console.WriteLine($"Tytuł: {this.Title}, Wykonawca: {this.Author}\nCharakterystyczne brzmienia:");
        }
    }
    class Jazz : Song
    {
        public string Sound { get; }

        public Jazz(string title, string author) : base(title, author)
        {
            this.Sound = "Improwizacja i dowolna forma";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine(this.Sound);
        }
    }

    class Rock : Jazz
    {
        public string Sound { get; }

        public Rock(string title, string author) : base(title, author)
        {
            this.Sound = "Gitarowe riffy i perkusja";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine(this.Sound);
        }
    }

    class ChristianRock : Rock
    {
        public string Sound { get; }

        public ChristianRock(string title, string author) : base(title, author)
        {
            this.Sound = "Teksty o podłożu religijnym";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine(this.Sound);
        }
    }

    class Disco : ChristianRock
    {
        public string Sound { get; }

        public Disco(string title, string author) : base(title, author)
        {
            this.Sound = "Lekkie wokale i bas";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine(this.Sound);
        }
    }

    class DiscoPolo : Disco
    {
        public string Sound { get; }

        public DiscoPolo(string title, string author) : base(title, author)
        {
            this.Sound = "Melodyczne wokale i lekkie dźwięki";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine(this.Sound);
        }
    }

    class Player
    {
        public List<Song> Playlist { get; set; }

        public Player()
        {
            Playlist = new List<Song>();
        }

        public void Add(Song song)
        {
            this.Playlist.Add(song);
        }
        public void Remove(int songNumber)
        {
            this.Playlist.RemoveAt(songNumber);
        }
        public void Play(int songNumber)
        {
            Console.Clear();
            this.Playlist[songNumber].Play();
            for(int i = 0; i < 20; i++)
            {
                Console.Write(">>");
                Thread.Sleep(500);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            while (true)
            {
                Console.WriteLine("Podaj tytuł utworu: ");
                string title = Console.ReadLine();

                Console.WriteLine("Podaj wykonawcę: ");
                string author = Console.ReadLine();

                switch(PickGenre())
                {
                    case 1:
                        Jazz jazz = new Jazz(title, author);
                        player.Playlist.Add(jazz);
                        break;
                    case 2:
                        Rock rock = new Rock(title, author);
                        player.Playlist.Add(rock);
                        break;
                    case 3:
                        ChristianRock christianRock = new ChristianRock(title, author);
                        player.Playlist.Add(christianRock);
                        break;
                    case 4:
                        Disco disco = new Disco(title, author);
                        player.Playlist.Add(disco);
                        break;
                    case 5:
                        DiscoPolo discoPolo= new DiscoPolo(title, author);
                        player.Playlist.Add(discoPolo);
                        break;
                }
                Console.WriteLine("Czy chczesz dodać kolejny utwór?");
                Console.WriteLine("1. Tak");
                Console.WriteLine("2. Nie");

                if (Convert.ToInt32(Console.ReadLine()) == 2)
                    break;
            }
            for (int i = 0; i < player.Playlist.Count; i++) 
            {
                player.Play(i);
                Console.WriteLine("\n");
            }
        }

        static int PickGenre()
        {
            Console.WriteLine("1. Jazz");
            Console.WriteLine("2. Rock");
            Console.WriteLine("3. Christian Rock");
            Console.WriteLine("4. Disco");
            Console.WriteLine("5. Disco Polo");

            return Convert.ToInt32(Console.ReadLine());
        }
    }
}