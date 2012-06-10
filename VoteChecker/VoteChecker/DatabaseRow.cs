
namespace VoteChecker
{
    public struct DatabaseRow
    {

        public int Ballot
        {
            get;
            set;
        }

        public string Barcode
        {
            get;
            set;
        }

        public bool Checked
        {
            get;
            set;
        }

        public string Group
        {
            get;
            set;
        }

        public int Packet
        {
            get;
            set;
        }

        public string TimeStamp
        {
            get;
            set;
        }
    }
}
