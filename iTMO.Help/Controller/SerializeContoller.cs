﻿using iTMO.Help.Model;
using iTMO.Help.Model.ViewReady;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace iTMO.Help.Controller
{
    class SerializeData<TValue>
    {
        public TValue   Data    { get; set; }
        public bool     IsValid { get; set; } = false;
        public string   Message { get; set; }
    }

    class SerializeContoller
    {
        public static SerializeData<List<ExamVR>> ToExamViewReady(string data)
        {
            SerializeData<List<ExamVR>> serializedData = new SerializeData<List<ExamVR>>();
            ScheduleExam exams      = null;
            List<ExamVR> dataList = new List<ExamVR>();

            try
            {
                exams = JsonConvert.DeserializeObject<ScheduleExam>(data);

                if (exams.faculties != null 
                    && exams.faculties.Capacity != 0 
                    && exams.faculties[0].departments != null
                    && exams.faculties[0].departments.Capacity != 0
                    && exams.faculties[0].departments[0].groups != null
                    && exams.faculties[0].departments[0].groups.Capacity != 0
                    && exams.faculties[0].departments[0].groups[0].exams_schedule != null)
                {
                    var examScheduleList = exams.faculties[0].departments[0].groups[0].exams_schedule;
                    foreach (ExamsSchedule exam in examScheduleList)
                    {
                        try
                        {
                            dataList.Add(new ExamVR
                            {
                                DateAdviceStr   = exam.advice_date,
                                DateExamStr     = exam.exam_date,
                                TimeAdvice      = exam.advice_time,
                                TimeExam        = exam.exam_time,
                                Subject         = exam.subject,
                                WeekdayAdvice   = exam.advice_day_text,
                                WeekdayExam     = exam.exam_day_text,
                                Teacher         = exam.teachers[0].teacher_name,
                                RoomAdvice      = exam.auditories[1].auditory_name,
                                RoomExam        = exam.auditories[0].auditory_name,
                            });
                        }
                        catch (ArgumentNullException ex) { }
                        catch (FormatException ex)       { }
                    }
                    serializedData.Data = dataList;
                    serializedData.IsValid = true;
                }
                else throw new ArgumentNullException("Group number is probably Invalid!");
            }
            catch (JsonSerializationException ex)   { serializedData.Message = "Json Parse Error"; }
            catch (ArgumentNullException ex)        { serializedData.Message = ex.Message; }
            catch (Exception ex)                    { serializedData.Message = "Unexpected Server Response"; }

            return serializedData;
        }

        public static SerializeData<List<ScheduleVR>> ToScheduleViewReady(string data)
        {
            SerializeData<List<ScheduleVR>> serializedData = new SerializeData<List<ScheduleVR>>();
            Schedule            schedule        = null;
            List<ScheduleVR>    listScheduleVR  = new List<ScheduleVR>();

            try
            {
                schedule = JsonConvert.DeserializeObject<Schedule>(data);

                if(schedule == null)
                {

                }
            }
            catch (JsonSerializationException ex)
            {

            }
            return serializedData;
        }

        public static SerializeData<Journal> ToJournalView(string data)
        {
            SerializeData<Journal> serializedData = new SerializeData<Journal>();
            Journal journal = null;

            try
            {
                serializedData.Data = journal = JsonConvert.DeserializeObject<Journal>(data);
                serializedData.IsValid = true;
            }
            catch (JsonSerializationException ex)
            {

            }
            return serializedData;
        }

        public static SerializeData<JournalChangeLog> ToJournalChangeLogView(string data)
        {
            SerializeData<JournalChangeLog> serializedData = new SerializeData<JournalChangeLog>();
            JournalChangeLog journalChangeLog = null;

            try
            {
                journalChangeLog = JsonConvert.DeserializeObject<JournalChangeLog>(data);
            }
            catch (JsonSerializationException ex)
            {

            }
            return serializedData;
        }

        public static SerializeData<MessageDe> ToMessageDeView(string data)
        {
            SerializeData<MessageDe> serializedData = new SerializeData<MessageDe>();
            MessageDe messages = null;

            try
            {
                messages = JsonConvert.DeserializeObject<MessageDe>(data);
            }
            catch (JsonSerializationException ex)
            {

            }
            return serializedData;
        }
    }
}
