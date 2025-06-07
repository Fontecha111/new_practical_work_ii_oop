using oppguidedpw;
namespace MAUI
{
    public class User : Operations
    {
        private string name;
        private string username;
        private string password;
        private int operationCount = 0;

        public User(string name, string username, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getName()
        {
            return this.name;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine("USER INFO");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Operations: {operationCount}");
        }

        public void IncrementOperation()
        {
            operationCount++;
        }

        public int getOperationCount()
        {
            return operationCount;
        }
    }
}