/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.util.LinkedList;
import java.util.List;
import java.util.Vector;

/**
 *
 * @author admin-c
 */
public class Job {
    
    private String Job_description;
    private int min_personal_score;// ניקוד מבחן אישיות מינמאלי
    private int min_mental_scoring;//ניקוד מבחן שכלי מינמאלי
    private int min_general_questions_score;//ניקוד שאלות כלליות  מינמאלי
    private List<Candidate> list_per_job;//3 מועמדים למשרה
    
    public String getJob_description() {
        return Job_description;
    }

    public void setJob_description(String Job_description) {
        this.Job_description = Job_description;
    }

    public int getMin_personal_score() {
        return min_personal_score;
    }

    public void setMin_personal_score(int min_personal_score) {
        this.min_personal_score = min_personal_score;
    }

    public int getMin_mental_scoring() {
        return min_mental_scoring;
    }

    public void setMin_mental_scoring(int min_mental_scoring) {
        this.min_mental_scoring = min_mental_scoring;
    }

    public int getMin_general_questions_score() {
        return min_general_questions_score;
    }

    public void setMin_general_questions_score(int min_general_questions_score) {
        this.min_general_questions_score = min_general_questions_score;
    }

    public List<Candidate> getList_per_job() {
        return list_per_job;
    }

    public void AddtoList_per_job(Candidate c) {
        this.list_per_job.add(c);
    }

    public Job(String Job_description, int min_personal_score, int min_mental_scoring, int min_general_questions_score) {
        this.Job_description = Job_description;
        this.min_personal_score = min_personal_score;
        this.min_mental_scoring = min_mental_scoring;
        this.min_general_questions_score = min_general_questions_score;
        this.list_per_job = new Vector<>();
    }

        
}
