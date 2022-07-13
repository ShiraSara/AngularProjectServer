/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

/**
 *
 * @author admin-c
 */
public class Client {
    
    private Socket socket;//שקע דרכו מתחברים לשרת

    public Client() throws IOException {
        socket=new Socket(Server.ADDRESS,Server.PORT);//איתחול הסוקט עם פרטי השרת המתאימים
    }
    
    public  void GetCandidate(Candidate c) throws IOException
    {
           ObjectOutputStream  writer=new ObjectOutputStream(socket.getOutputStream());
        //הגדרת אובייקט מובנה לצורך שליחת מידע לשרת
        writer.writeObject(c);
        writer.flush();
    
    }
}
