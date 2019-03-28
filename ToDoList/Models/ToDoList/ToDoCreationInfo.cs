using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Models.ToDoList
{
    public class ToDoCreationInfo
    {
        public ToDoCreationInfo(string userId, string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            this.UserId = userId;
            this.Text = text;
        }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит ToDo
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Текст ToDo
        /// </summary>
        public string Text { get; set; }
    }
}
