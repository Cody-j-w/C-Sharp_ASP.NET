using System;
using System.Collections;

namespace ViewModel.Models
{
    public class User
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
    }

    public class UserList : IEnumerable
    {
        private User[] _users;
        public UserList(User[] uArray)
        {
            _users = new User[uArray.Length];

            for (int i = 0; i<uArray.Length; i++)
            {
                _users[i] = uArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public UserListEnum GetEnumerator()
        {
            return new UserListEnum(_users);
        }
    }

    public class UserListEnum : IEnumerator
    {
        public User[] _users;

        int position = -1;

        public UserListEnum(User[] list)
        {
            _users = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _users.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current{
            get
            {
                return Current;
            }
        }
        public User Current
        {
            get
            {
                try
                {
                    return _users[position];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}