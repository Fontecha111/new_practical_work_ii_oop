namespace MAUI
{
    public interface Operations
    {
        void setName(string name);
        void setUsername(string username);
        void setPassword(string password);

        string getName();
        string getUsername();
        string getPassword();

        public void DisplayUserInfo();
        public void IncrementOperation();
    }
}