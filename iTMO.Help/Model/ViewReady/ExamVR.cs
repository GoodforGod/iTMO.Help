﻿using System;

namespace iTMO.Help.Model.ViewReady
{
    public class ExamVR
    {
        public string DateExam      { get; set; } = "";
        public string DateAdvice    { get; set; } = "";

        public string WeekdayExam   { get; set; } = "";
        public string WeekdayAdvice { get; set; } = "";
        public string TimeExam      { get; set; } = "";
        public string TimeAdvice    { get; set; } = "";
        public string RoomExam      { get; set; } = "";
        public string RoomAdvice    { get; set; } = "";
        public string Subject       { get; set; } = "";
        public string Teacher       { get; set; } = "";

        public override string ToString()
        {
            return "Subject : " + Subject 
                + ", Teacher : " + Teacher 
                + "\n[ Exam on : " + DateExam 
                + ", in " + TimeExam 
                + ", Room : " + RoomExam + " ] "
                + "\n[ Advice on" + DateAdvice
                + ", in " + TimeAdvice
                + ", Room : " + RoomAdvice + " ]";
        }
    }
}
