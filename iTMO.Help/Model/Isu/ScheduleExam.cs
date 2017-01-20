﻿using System.Collections.Generic;

namespace iTMO.Help.Model
{
    public class Teacher
    {
        public string teacher_name  { get; set; } = "";
        public string teacher_id    { get; set; } = "-1";
    }

    public class Auditory
    {
        public string type              { get; set; } = "";
        public string auditory_name     { get; set; } = "";
        public string auditory_address  { get; set; } = "";
    }

    public class ExamsSchedule
    {
        public string   subject         { get; set; } = "";
        public int      type            { get; set; } = -1;
        public string   type_name       { get; set; } = "";
        public string   exam_time       { get; set; } = "";
        public string   exam_date       { get; set; } = "";
        public int      exam_day        { get; set; } = -1;
        public string   exam_day_text   { get; set; } = "";
        public string   advice_time     { get; set; } = "";
        public string   advice_date     { get; set; } = "";
        public int      advice_day      { get; set; } = 0;
        public string   advice_day_text { get; set; } = "";

        public List<object>     dates       { get; set; } = new List<object>();
        public List<Teacher>    teachers    { get; set; } = new List<Teacher>();
        public List<Auditory>   auditories  { get; set; } = new List<Auditory>();
    }

    public class Group
    {
        public string              group_name     { get; set; } = "";

        public List<object>        study_schedule { get; set; } = new List<object>();
        public List<ExamsSchedule> exams_schedule { get; set; } = new List<ExamsSchedule>();
    }

    public class Department
    {
        public string   department_name { get; set; } = "";
        public int      department_id   { get; set; } = -1;

        public List<Group> groups { get; set; } = new List<Group>();
    }

    public class Faculty
    {
        public string   faculty_name    { get; set; } = "";
        public int      faculty_id      { get; set; } = -1;

        public List<Department> departments { get; set; }
    }

    public class ScheduleExam
    {
        public List<Faculty> faculties { get; set; }
    }
}
