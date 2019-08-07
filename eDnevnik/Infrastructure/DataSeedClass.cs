using eDnevnik.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eDnevnik.Infrastructure
{
    public class DataSeedClass : DropCreateDatabaseAlways<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            //*************************//
            //Adding roles

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            RoleManager.Create(new IdentityRole("users"));
            RoleManager.Create(new IdentityRole("admins"));
            RoleManager.Create(new IdentityRole("pupils"));
            RoleManager.Create(new IdentityRole("teachers"));
            RoleManager.Create(new IdentityRole("parents"));

            //*************************//            
            // Subjects

            List<Subject> subjects = new List<Subject>();

            Subject sub_1 = new Subject()
            {
                SubjectName = "Matematika",
                FundOfClasses = 5                
            };

            Subject sub_2 = new Subject()
            {
                SubjectName = "Likovno",
                FundOfClasses = 2
            };

            Subject sub_3 = new Subject()
            {
                SubjectName = "Geografija",
                FundOfClasses = 3
            };

            Subject sub_4 = new Subject()
            {
                SubjectName = "Srpski jezik",
                FundOfClasses = 5
            };

            subjects.Add(sub_1);
            subjects.Add(sub_2);
            subjects.Add(sub_3);
            subjects.Add(sub_4);

            context.Subjects.AddRange(subjects);

            //*************************//
            // Classes            

            List<Class> classses = new List<Class>();

            Class fifthOne = new Class() {Id = 1, ClassYear = 5, ClassNumber = 1 };
            Class fifthTwo = new Class() {Id = 2, ClassYear = 5, ClassNumber = 2 };

            classses.Add(fifthOne);
            classses.Add(fifthTwo);

            context.Classes.AddRange(classses);

            //*************************//
            // Teachers        

            string teacherPassword_1 = "teacherPass1";
            string teacherPassword_2 = "teacherPass2";
            string teacherPassword_3 = "teacherPass3";
            string teacherPassword_4 = "teacherPass4";


            Teacher teacher_1 = new Teacher() { UserName = "teacher1", TeacherName = "Djurdija", TeacherSurname = "Jaksic", TeachingSubject = sub_1 };
            Teacher teacher_2 = new Teacher() { UserName = "teacher2", TeacherName = "Draginja", TeacherSurname = "Romanov", TeachingSubject = sub_2 };
            Teacher teacher_3 = new Teacher() { UserName = "teacher3", TeacherName = "Ranka", TeacherSurname = "Anojcic", TeachingSubject = sub_3 };
            Teacher teacher_4 = new Teacher() { UserName = "teacher4", TeacherName = "Zatezalo", TeacherSurname = "Strahinja", TeachingSubject = sub_4 };

            UserManager.Create(teacher_1, teacherPassword_1);
            UserManager.Create(teacher_2, teacherPassword_2);
            UserManager.Create(teacher_3, teacherPassword_3);
            UserManager.Create(teacher_4, teacherPassword_4);

            UserManager.AddToRole(teacher_1.Id, "teachers");
            UserManager.AddToRole(teacher_2.Id, "teachers");
            UserManager.AddToRole(teacher_3.Id, "teachers");
            UserManager.AddToRole(teacher_4.Id, "teachers");

            
            //*************************//
            // Teachers Classes

            List<TeacherClass> teachersClasses = new List<TeacherClass>();

            TeacherClass tc_1 = new TeacherClass()
            {                
                Class_Id = 1,
                Teacher = teacher_1,
                Class = fifthOne
            };
            TeacherClass tc_21 = new TeacherClass()
            {                
                Class_Id = 1,
                Teacher = teacher_2,
                Class = fifthOne
            };
            TeacherClass tc_22 = new TeacherClass()
            {
                Class_Id = 2,
                Teacher = teacher_2,
                Class = fifthTwo
            };
            TeacherClass tc_31 = new TeacherClass()
            {
                Class_Id = 1,
                Teacher = teacher_3,
                Class = fifthOne
            };
            TeacherClass tc_32 = new TeacherClass()
            {
                Class_Id = 2,
                Teacher = teacher_3,
                Class = fifthTwo
            };
            TeacherClass tc_4 = new TeacherClass()
            {                
                Class_Id = 1,
                Teacher = teacher_4,
                Class = fifthTwo
            };

            teachersClasses.Add(tc_1);
            teachersClasses.Add(tc_21);
            teachersClasses.Add(tc_22);
            teachersClasses.Add(tc_31);
            teachersClasses.Add(tc_32);
            teachersClasses.Add(tc_4);

            context.TeacherClasses.AddRange(teachersClasses);

            //*************************//
            // Marks

            List<Mark> marks = new List<Mark>();

            Mark mark_1 = new Mark()
            {
                Subject = sub_1,
                MarkValue = Marks.Five,
                Semester = Semesters.First
            };

            Mark mark_2 = new Mark()
            {
                Subject = sub_2,
                MarkValue = Marks.Four,
                Semester = Semesters.First
            };

            Mark mark_3 = new Mark()
            {
                Subject = sub_3,
                MarkValue = Marks.Five,
                Semester = Semesters.First
            };

            Mark mark_4 = new Mark()
            {
                Subject = sub_4,
                MarkValue = Marks.Two,
                Semester = Semesters.First
            };

            marks.Add(mark_1);
            marks.Add(mark_2);
            marks.Add(mark_3);
            marks.Add(mark_4);

            context.Marks.AddRange(marks);

            //*************************//
            // Pupils        
            List<Mark> marks1 = new List<Mark>();
            List<Mark> marks2 = new List<Mark>();
            List<Mark> marks3 = new List<Mark>();
            List<Mark> marks4 = new List<Mark>();
            List<Mark> marks5 = new List<Mark>();
            List<Mark> marks6 = new List<Mark>();

            marks1.Add(mark_1);
            marks1.Add(mark_2);
            marks1.Add(mark_3);

            marks2.Add(mark_1);
            marks2.Add(mark_2);
            marks2.Add(mark_3);

            marks3.Add(mark_1);
            marks3.Add(mark_2);
            marks3.Add(mark_3);

            marks4.Add(mark_2);
            marks4.Add(mark_3);
            marks4.Add(mark_4);

            marks5.Add(mark_2);
            marks5.Add(mark_3);
            marks5.Add(mark_4);

            marks5.Add(mark_2);
            marks5.Add(mark_3);
            marks5.Add(mark_4);

            string pupilPassword_1 = "pupilPass1";
            string pupilPassword_2 = "pupilPass2";
            string pupilPassword_3 = "pupilPass3";
            string pupilPassword_4 = "pupilPass4";
            string pupilPassword_5 = "pupilPass5";
            string pupilPassword_6 = "pupilPass6";

            Pupil pupil_1 = new Pupil() { UserName = "pupil1", PupilName = "Viktor", PupilSurname = "Veres", Marks = marks1 /*Marks = marks*/, PupilClass = fifthOne };
            Pupil pupil_2 = new Pupil() { UserName = "pupil2", PupilName = "Snezana", PupilSurname = "Arambasic", Marks = marks2, PupilClass = fifthOne };
            Pupil pupil_3 = new Pupil() { UserName = "pupil3", PupilName = "Janko", PupilSurname = "Jankovic", Marks = marks3, PupilClass = fifthOne };
            Pupil pupil_4 = new Pupil() { UserName = "pupil4", PupilName = "Marko", PupilSurname = "Markovic", Marks = marks4, PupilClass = fifthTwo };
            Pupil pupil_5 = new Pupil() { UserName = "pupil5", PupilName = "Bole", PupilSurname = "Stoimenov", Marks = marks5, PupilClass = fifthTwo };
            Pupil pupil_6 = new Pupil() { UserName = "pupil6", PupilName = "Rista", PupilSurname = "Stoimenov", Marks = marks6, PupilClass = fifthTwo };

            UserManager.Create(pupil_1, pupilPassword_1);
            UserManager.Create(pupil_2, pupilPassword_2);
            UserManager.Create(pupil_3, pupilPassword_3);
            UserManager.Create(pupil_4, pupilPassword_4);
            UserManager.Create(pupil_5, pupilPassword_5);
            UserManager.Create(pupil_6, pupilPassword_6);

            UserManager.AddToRole(pupil_1.Id, "pupils");
            UserManager.AddToRole(pupil_2.Id, "pupils");
            UserManager.AddToRole(pupil_3.Id, "pupils");
            UserManager.AddToRole(pupil_4.Id, "pupils");
            UserManager.AddToRole(pupil_5.Id, "pupils");
            UserManager.AddToRole(pupil_6.Id, "pupils");
            
            //*************************//
            // Parents

            List<Pupil> Parents_1_Children = new List<Pupil>();
            List<Pupil> Parents_2_Children = new List<Pupil>();
            List<Pupil> Parents_3_Children = new List<Pupil>();
            List<Pupil> Parents_4_Children = new List<Pupil>();
            List<Pupil> Parents_5_Children = new List<Pupil>();

            Parents_1_Children.Add(pupil_1);
            Parents_2_Children.Add(pupil_2);
            Parents_3_Children.Add(pupil_3);
            Parents_4_Children.Add(pupil_4);
            Parents_5_Children.Add(pupil_5);
            Parents_5_Children.Add(pupil_6);

            string parentPassword_1 = "parentPass1";
            string parentPassword_2 = "parentPass2";
            string parentPassword_3 = "parentPass3";
            string parentPassword_4 = "parentPass4";
            string parentPassword_5 = "parentPass5";

            Parent parent_1 = new Parent() { UserName = "parent1", ParentName = "Deze", ParentSurname = "Veres", Email = "veres@gmail.com", Pupils = Parents_1_Children };
            Parent parent_2 = new Parent() { UserName = "parent2", ParentName = "Dragoljub", ParentSurname = "Arambasic", Email = "aramb@gmail.com", Pupils = Parents_2_Children };
            Parent parent_3 = new Parent() { UserName = "parent3", ParentName = "Nikola", ParentSurname = "Jankovic", Email = "janko@gmail.com", Pupils = Parents_3_Children };
            Parent parent_4 = new Parent() { UserName = "parent4", ParentName = "Marijan", ParentSurname = "Markovic", Email = "marko@gmail.com", Pupils = Parents_4_Children };
            Parent parent_5 = new Parent() { UserName = "parent5", ParentName = "Steva", ParentSurname = "Stoimenov", Email = "stoim@gmail.com", Pupils = Parents_5_Children };           

            UserManager.Create(parent_1, parentPassword_1);
            UserManager.Create(parent_2, parentPassword_2);
            UserManager.Create(parent_3, parentPassword_3);
            UserManager.Create(parent_4, parentPassword_4);
            UserManager.Create(parent_5, parentPassword_5);

            UserManager.AddToRole(parent_1.Id, "parents");
            UserManager.AddToRole(parent_2.Id, "parents");
            UserManager.AddToRole(parent_3.Id, "parents");
            UserManager.AddToRole(parent_4.Id, "parents");
            UserManager.AddToRole(parent_5.Id, "parents");

            //*************************//
            //Admin

            User admin = new User() { UserName = "admin" };

            string adminPassword = "adminPass";

            UserManager.Create(admin, adminPassword);

            UserManager.AddToRole(admin.Id, "admins");

            //*************************//
            // Save changes

            context.SaveChanges();

            base.Seed(context);
        }
    }
}