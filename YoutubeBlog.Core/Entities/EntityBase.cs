

using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        protected static readonly Random _random = new Random();
        protected const string _allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:',.<>?";
        protected const int _minNameLength = 4;
        protected const int _maxNameLength = 20;
        protected static readonly HashSet<string> _usedSecNames = new HashSet<string>();
        protected static readonly object _lockObject = new object();

        private static string GenerateUniqueSecName()
        {
            string secName;
            int attempts = 0;
            do
            {
                secName = GenerateRandomName();
                attempts++;
                if (attempts > (_maxNameLength - _minNameLength) * _allowedChars.Length)
                {
                    throw new InvalidOperationException("All possible SecNames are used.");
                }
            } while (!IsUniqueSecName(secName)); // Keep generating until a unique SecName is found
            return secName;
        }

        protected static string GenerateRandomName()
        {
            int nameLength = _random.Next(_minNameLength, _maxNameLength + 1);
            char[] nameArray = new char[nameLength];

            for (int i = 0; i < nameLength; i++)
            {
                nameArray[i] = _allowedChars[_random.Next(_allowedChars.Length)];
            }

            return new string(nameArray);
        }

        protected static bool IsUniqueSecName(string secName)
        {
            lock (_lockObject)
            {
                return _usedSecNames.Add(secName);
            }
        }

        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; } = "Undefined";
        public virtual string? DeletedBy { get; set; } = "Undefined";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public virtual DateTime? DeletedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = false;
        public virtual string SecName { get; set; } = GenerateUniqueSecName();
    }


}
