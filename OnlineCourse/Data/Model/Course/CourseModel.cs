﻿using OnlineCourse.Data.Entity.Course;

namespace OnlineCourse.Data.Model.Course
{
    public class CourseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string BeginLessonId {  get; set; }
        public bool IsActive { get; set; }
    }
}
