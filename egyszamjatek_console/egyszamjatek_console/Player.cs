namespace egyszamjatek_console
{
    public class Player
    {
        public string Name { get; set; }

        public int[] Tips { get; set; }

        public Player(string line)
        {
            var sV = line.Split(' ');
            int[] sV_Array = { int.Parse(sV[1]), int.Parse(sV[2]), int.Parse(sV[3]), int.Parse(sV[4]) };
            Name = sV[0];
            Tips = sV_Array;
        }
    }
}