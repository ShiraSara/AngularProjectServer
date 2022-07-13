/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import javax.swing.JTextArea;

/**
 *
 * @author admin-c
 */
public class ServerThread extends Thread{
    
     private Socket clientSocket;//הלקוח שאיתו מתקשרים
    private JTextArea console;//האזור לתוכו מדפיסים הודעות

    public ServerThread(Socket clientSocket) {
        this.clientSocket = clientSocket;
        this.console = console;
    }
    
     @Override
    public void run() {
        ObjectOutputStream writer=null;
        ObjectInputStream reader=null;
        try {
            reader = new ObjectInputStream(clientSocket.getInputStream());
            writer = new ObjectOutputStream(clientSocket.getOutputStream());
        } catch (Exception e) {
            e.printStackTrace();
        }
        while (true) {

            try {
                Candidate c =(Candidate)reader.readObject();
                System.out.println("התקבלה פניה");
                Server.addToListAndUpdate(c);
                
            } catch (Exception e) {
                break;
                
            }

        }
    }
    
}
