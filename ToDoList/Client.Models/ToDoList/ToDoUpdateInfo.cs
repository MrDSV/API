using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Client.Models.ToDoList
{
    [DataContract]
    public class ToDoUpdateInfo
    {
        /// <summary>
        /// Флаг, указывающий выполнение ToDo
        /// </summary>
        [DataMember(IsRequired = false)]
        public bool? IsDone { get; set; }

        /// <summary>
        /// Текст ToDo
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Text { get; set; }

    }
}
