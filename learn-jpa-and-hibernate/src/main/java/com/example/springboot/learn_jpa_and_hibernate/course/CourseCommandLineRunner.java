package com.example.springboot.learn_jpa_and_hibernate.course;

import com.example.springboot.learn_jpa_and_hibernate.course.jdbc.CourseJdbcRepository;
import com.example.springboot.learn_jpa_and_hibernate.course.jpa.CourseJpaRepository;
import com.example.springboot.learn_jpa_and_hibernate.course.springdatajpa.CourseSpringDataJpaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class CourseCommandLineRunner implements CommandLineRunner {

//    @Autowired
//    private CourseJdbcRepository repository;

//    @Autowired
//    private CourseJpaRepository courseJpaRepository;

    @Autowired
    private CourseSpringDataJpaRepository repository;

    @Override
    public void run(String... args) throws Exception {
//        repository.insert(new Course(1, "Learn AWS", "in28minutes"));
//        repository.insert(new Course(2, "Learn Azure", "in28minutes"));
//        repository.insert(new Course(3, "Learn AWS", "in28minutes"));
//        repository.deleteById(1);
//        System.out.println(repository.findById(2));
//        System.out.println(repository.findById(3));

//        courseJpaRepository.insert(new Course(1, "Learn AWS Jpa", "in28minutes"));
//        courseJpaRepository.insert(new Course(2, "Learn Azure Jpa", "in28minutes"));
//        courseJpaRepository.insert(new Course(3, "Learn DevOps Jpa", "in28minutes"));
//
//        courseJpaRepository.deleteById(1);
//        System.out.println(courseJpaRepository.findById(2));
//        System.out.println(courseJpaRepository.findById(3));

        repository.save(new Course(1, "Learn AWS", "in28minutes"));
        repository.save(new Course(2, "Learn Azure", "in28minutes"));
        repository.save(new Course(3, "Learn AWS", "in28minutes"));

        repository.deleteById(1l);

        System.out.println(repository.findById(2l));
        System.out.println(repository.findById(3l));


        System.out.println(repository.findAll());
        System.out.println(repository.count());

        System.out.println(repository.findByAuthor("in28minutes"));
        System.out.println(repository.findByName("Learn AWS"));

    }
}
