import java.io.*;

import java.nio.Buffer;

public class Main {

    public static void main(String[] args) {
        // args[0] must be file path
        // args[1] must be out path
        String path = args[0];
        String outPath = args[1];
        //File file = new File(path);

        try {
            PrintStream out = new PrintStream(new File(outPath));
            BufferedReader buff = new BufferedReader(new FileReader(path));
            String line = buff.readLine();
            // skips first line
            line = buff.readLine();
            while (line != null ) {
                String[] tokens = line.split(" ");
                if (tokens.length > 1) {
                    // PRE: the token must have at least 3 chars
                    String cSharpLine = "public int " + tokens[0].substring(2, tokens[0].length() - 1) + " { get; set; }";
                    out.println(cSharpLine);
                    System.out.println(cSharpLine);

                } else {
                    break;
                }

                line = buff.readLine();
            }
        } catch (FileNotFoundException e) {
            System.out.println("Illicit file path");
        }
        catch (IOException e){
            System.out.println("Reading the file failed");
        }
    }
}
