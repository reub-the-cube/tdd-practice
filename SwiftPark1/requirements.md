Write code that calculates a student's progress in a course based on a completed lessons and total lessons.

For example, a course has 4 lessons, a student has completed 3 of those lessons, so the student's progress on that course is 75%.

Constraints:
- Students may enrol on multiple courses
- A course may contain multiple lessons
- Lessons can be shared by other courses
- Course progress is tracked by the number of lessons completed by a student for a given course

---
Instructor ->> Add course  
Student -> List courses  
Student ->> Enrol on course  
Student ->> Complete lesson  
