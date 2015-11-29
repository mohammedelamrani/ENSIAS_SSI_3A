package knapsac;

import java.math.BigInteger;
import java.util.*;

public class Knapsac {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        //1ère étape : génération de clés
        double test = Math.random();
        //System.out.println(test);
        int n = 48;
        long[] a = new long[n];
        Random rn = new Random();
        a[0] = Math.round(10 * test);
        long somme = a[0];
        //génération de la suite super croissante
        for (int i = 1; i < n; i++) {
            a[i] = 2 * a[i - 1] + Math.round(10 * Math.random() + 1);
            somme += a[i];
        }
        //*
        // génértion de A et N premiers avec N>somme des ai
        long N = somme + Math.round(100 * Math.random());
        long A = Math.round((N - 1) * Math.random());
        while (pgdc(N, A) != 1) {
            A = Math.round((N - 1) * Math.random());
        }
        //*
        //génération de la clé publique
    
        long[] b = new long[n];
        for (int i = 0; i < n; i++) {
            b[i] = modmul(a[i], A, N);
        }
        //*génération de clés terminée
        //affichage
        System.out.println("Génération de clés");
        System.out.println("La clé privée est : ");
        System.out.print("La suite super croissante : ");
        for(int i=0; i<n; i++) {
            System.out.print(a[i]+"\t");
            
        }
        System.out.print('\n');
        System.out.println("A = "+A+"\t\tN = "+N);
        System.out.println("La clé publique est : ");
        for(int i=0; i<n; i++) {
            System.out.print(b[i]+"\t");
            
        }
        System.out.print('\n');
        //2ème étape : chiffrement
        System.out.println("\nChiffrement: ");
        Scanner sc =  new Scanner(System.in);
        while(true) {
            System.out.println("Veuillez entrer un message : ");
        String message = sc.nextLine();
        System.out.println("le message à chiffrer est : " + message);
        System.out.println("sa repésentation binaire: "+strToBi(message));
        List<Long> cList = new ArrayList<>();
        cList = knapCipher(n, b, strToBi(message));
        System.out.println("le chiffré de ce message est ");

        System.out.println(cList);
        //3ème étape : déchiffrement
        String messageP = knapDecipher(n, a, N, Amoins(A, N), cList);
        System.out.println("le message déchiffré en binaire est : ");
        System.out.println(messageP);
        System.out.println("le message déchiffré en clair : ");
        System.out.println(biToStr(messageP));
        }

    }
    //cette fonction retourne le pgdc de deux nombres(long) a et b
    public static long pgdc(long a, long b) {
        BigInteger b1 = new BigInteger("" + a);
        BigInteger b2 = new BigInteger("" + b);
        BigInteger gcd = b1.gcd(b2);
        return gcd.longValue();

    }
    //*
    
    //La fonction strToBi prend une chaine de caractère et retourne sa représentation binaire en ascii
    public static String strToBi(String s) {
        String bi = "";
        for (int i = 0; i < s.length(); i++) {
            if (Integer.toBinaryString((int) s.charAt(i)).length() < 8) {
                for (int j = 0; j < 8 - Integer.toBinaryString((int) s.charAt(i)).length(); j++) {
                    bi += "0";
                }
            }
            bi += Integer.toBinaryString((int) s.charAt(i));
        }
        return bi;
    }
    //*
    //prend une séquence binaire codée en ascii et retourne la chaine de caractère qui lui correspond
    public static String biToStr(String bi) {
        String str = "";
        byte b = 0;
        for (int i = 0; i < bi.length(); i++) {

            if (i % 8 == 7 && i > 0) {
                b += Math.pow(2, 7 - i % 8) * (int) (bi.charAt(i) - 48);
                str += (char) b;
                b = 0;
            } else {
                b += Math.pow(2, 7 - i % 8) * (int) (bi.charAt(i) - 48);
            }
        }
        return str;
    }
    //*
    //knapCipher prend en paramètre la taille de bloc n, une clé publique b et une séquence binaire
    //elle retourne une liste dont chaque élément à l'index i est le chiffré du bloc i du message en décimal
    public static List knapCipher(int n, long[] b, String bi) {
        List cList = new ArrayList();
        long somme = 0;
        for (int i = 0; i < bi.length(); i++) {
            if ((i % n == n - 1 && i != 0) || i == bi.length() - 1) {
                somme += b[i % n] * ((int) (bi.charAt(i)) - 48);
                cList.add(somme);
                somme = 0;
            } else {
                somme += b[i % n] * ((int) (bi.charAt(i)) - 48);
            }
        }
        return cList;
    }
    //*
    /*Fonction pour déchiffrer, elle rprend la taille du bloc, la clé privée a et N et l'inverse de A
    et le chiffré sous forme de liste dont les élément sont les chiffrés de taille n
    elle retourne une séquence binaire*/
    public static String knapDecipher(int n, long[] a, long N, long Amoins, List<Long> l) {
        String bi = "";
        for (long c : l) {
            long p = modmul(c, Amoins, N);
            bi += solveEasy(a, p);
        }
        return bi;
    }
    //résoud une instance "facile" du problème de la somme des sous ensembles, elle prend une suite super croissante a et la somme recherchée p
    //la solution est une séquence binaire
    public static String solveEasy(long[] a, long p) {
        String bi = "";
        long pp = p;
        boolean stop = false;
        int i = a.length - 1;
        while (i > -1) {
            if (pp >= a[i]) {
                bi = "1" + bi;
                pp -= a[i];
            } else if (i >= 7 && pp < a[i - 7]) {
                i -= 7;
            } else {
                bi = "0" + bi;
            }
            i--;
        }
        return bi;
    }
    //retourne l'inverse de A mod N
    public static long Amoins(long A, long N) {
        BigInteger a = new BigInteger("" + A);
        BigInteger n = new BigInteger("" + N);
        return a.modInverse(n).longValue();
    }
    //effectue une multiplication modulaire de A et B mod N
    public static long modmul(long A, long B, long N) {
        BigInteger a = new BigInteger("" + A);
        BigInteger b = new BigInteger("" + B);
        BigInteger n = new BigInteger("" + N);
        BigInteger c = a.multiply(b);
        return c.mod(n).longValue();

    }
    
    
}
