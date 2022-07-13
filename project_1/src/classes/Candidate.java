/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.io.Serializable;
import jdk.nashorn.internal.codegen.CompilerConstants;

/**
 *
 * @author admin-c
 */
public class Candidate implements Serializable, Comparable<Candidate>{
    
    private String tz;
    private String email;
    private int personal_score;//ניקוד מבחן אישיות
    private int mental_scoring;//ניקוד מבחן שכלי
    private int general_questions_score;//ניקוד שאלות כלליות 

    public String getTz() {
        return tz;
    }

    public void setTz(String tz) {
        this.tz = tz;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getPersonal_score() {
        return personal_score;
    }

    public void setPersonal_score(int personal_score) {
        this.personal_score = personal_score;
    }

    public double getMental_scoring() {
        return mental_scoring;
    }

    public void setMental_scoring(int mental_scoring) {
        this.mental_scoring = mental_scoring;
    }

    public int getGeneral_questions_score() {
        return general_questions_score;
    }

    public void setGeneral_questions_score(int general_questions_score) {
        this.general_questions_score = general_questions_score;
    }
    //פעולה בונה
    public Candidate(String tz, String email, int personal_score, int mental_scoring, int general_questions_score) {
        this.tz = tz;
        this.email = email;
        this.personal_score = personal_score;
        this.mental_scoring = mental_scoring;
        this.general_questions_score = general_questions_score;
    }

    @Override
    public int compareTo(Candidate o) {
       int count=(int) (this.getGeneral_questions_score()+this.getPersonal_score()+this.getMental_scoring());
       int count1=(int)(o.getGeneral_questions_score()+o.getMental_scoring()+o.getPersonal_score());
       return count-count1;
    }
    
  
    
}
