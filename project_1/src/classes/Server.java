/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import GUI.serverForm;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Collection;
import java.util.Collections;
import java.util.List;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

public class Server extends Thread {

    public static final String ADDRESS = "localhost";//×›×ª×•×‘×ª ×”×©×¨×ª
    public static final int PORT = 1000;//×”×™×¦×™×�×” ×”×œ×•×’×™×ª ×“×¨×›×” ×”×©×¨×ª ×ž×�×–×™×Ÿ ×œ×—×™×‘×•×¨×™×�

    private static void clean(DefaultTableModel model) {
        for (int i = model.getRowCount() - 1; i >= 0; i--) {
            model.removeRow(i);
        }
    }
    String str1 = "";

    private static JTable job1;
    private static JTable job2;
    private static JTable job3;
    private ServerSocket serverSocket;
    private static List<Job> listJob;
    private static List<Candidate> listCandidate;

    public static void addToListAndUpdate(Candidate c) {
        synchronized (Server.class) {
            listCandidate.add(c);
            for (int i = 0; i < listJob.size(); i++) {
                if (c.getGeneral_questions_score() >= listJob.get(i).getMin_general_questions_score() && c.getMental_scoring() >= listJob.get(i).getMin_mental_scoring() && c.getPersonal_score() >= listJob.get(i).getMin_personal_score()) {
                    listJob.get(i).AddtoList_per_job(c);
                }
                Collections.sort(listJob.get(i).getList_per_job());
            }
        }

        //להציג מחדש את הנתונים בטבלאות
        DefaultTableModel model = (DefaultTableModel) job1.getModel();
        DefaultTableModel model1 = (DefaultTableModel) job2.getModel();
        DefaultTableModel model2 = (DefaultTableModel) job3.getModel();
        clean(model);
        clean(model1);
        clean(model2);
        for (int i = 0; i < 2; i++) {
            model.addRow(new Object[]{listJob.get(0).getList_per_job().get(i).getTz(), listJob.get(0).getList_per_job().get(i).getEmail(), listJob.get(0).getList_per_job().get(i).getMental_scoring(), listJob.get(0).getList_per_job().get(i).getGeneral_questions_score(), listJob.get(0).getList_per_job().get(i).getPersonal_score()});
            model1.addRow(new Object[]{listJob.get(1).getList_per_job().get(i).getTz(), listJob.get(1).getList_per_job().get(i).getEmail(), listJob.get(1).getList_per_job().get(i).getMental_scoring(), listJob.get(1).getList_per_job().get(i).getGeneral_questions_score(), listJob.get(1).getList_per_job().get(i).getPersonal_score()});
            model2.addRow(new Object[]{listJob.get(2).getList_per_job().get(i).getTz(), listJob.get(2).getList_per_job().get(i).getEmail(), listJob.get(2).getList_per_job().get(i).getMental_scoring(), listJob.get(2).getList_per_job().get(i).getGeneral_questions_score(), listJob.get(2).getList_per_job().get(i).getPersonal_score()});
        }
    }

//שדות
    public Server(JTable table1, JTable table2, JTable table3) throws IOException {
        listCandidate = new Vector<Candidate>();
        listJob = new Vector<Job>();
        Job j1 = new Job("בדיקת תוכנה", 1, 1, 1);
        Job j2 = new Job("מורה למוזיקה", 1, 1, 1);
        Job j3 = new Job("הנהלת חשבונות", 2, 2, 2);
        listJob.add(j3);
        listJob.add(j1);
        listJob.add(j2);
        this.serverSocket = new ServerSocket(PORT);
        job1 = table1;
        job2 = table2;
        job3 = table3;

    }

    @Override
    public void run() {
        try {
            listenToClients();
        } catch (IOException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void listenToClients() throws IOException, ClassNotFoundException {

        while (true)//×”×©×¨×ª ×ž×�×–×™×Ÿ ×›×œ ×”×–×ž×Ÿ ×œ×‘×§×©×•×ª
        {

            Socket clientSocket = serverSocket.accept();

            ServerThread t = new ServerThread(clientSocket);
            t.start();
        }
    }
}
