using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public static int w = 4;
    public static int h = 6;
    public static Target[,] targets = new Target[w, h];
    public static Tdc[,] tdcs = new Tdc[w, h];
    public static Search[,] searches = new Search[4, 3];
    public static Ultra ultra;
    public static ResetTargets resetTargetsButton;
    public static ResetTdcs resetTdcsButton;
    public static WarPeriod[] warPeriods = new WarPeriod[4];
    public static int[,] tdcTextureIndices = new int[w, h];
    public static int[,] tdcRolledIndices = new int[w, h];
    public static int[,] targetBackIndices = new int[w, h];
    public static int[,] targetFrontIndices = new int[w, h];
    public static int[,] searchIndices = new int[4, 3];
    public static int[,][] columnData = new int[4, 3][];
    public static int searchRow = 0;
    public static int searchCol = 0;
    public static bool searchIndicesLoaded = false;
    public static bool targetsRolled = false;
    public static int warPeriod = 1;
    public static int[] targetsPerColumn = new int[w];

    public static void fillCups(int[,,] cups)
    {
        // Cup token format: [back or front index, token index]

        // DD2t's
        cups[4, 0, 0] = 2;
        cups[4, 1, 0] = 26;
        cups[4, 0, 1] = 2;
        cups[4, 1, 1] = 26;
        cups[4, 0, 2] = 2;
        cups[4, 1, 2] = 25;
        cups[4, 0, 3] = 1;
        cups[4, 1, 3] = 22;
        cups[4, 0, 4] = 1;
        cups[4, 1, 4] = 26;
        cups[4, 0, 5] = 2;
        cups[4, 1, 5] = 24;
        cups[4, 0, 6] = 2;
        cups[4, 1, 6] = 22;
        cups[4, 0, 7] = 2;
        cups[4, 1, 7] = 22;
        cups[4, 0, 8] = 1;
        cups[4, 1, 8] = 25;
        cups[4, 0, 9] = 2;
        cups[4, 1, 9] = 25;
        cups[4, 0, 10] = 2;
        cups[4, 1, 10] = 25;
        cups[4, 0, 11] = 2;
        cups[4, 1, 11] = 27;
        cups[4, 0, 12] = 2;
        cups[4, 1, 12] = 23;
        cups[4, 0, 13] = 2;
        cups[4, 1, 13] = 22;
        cups[4, 0, 14] = 2;
        cups[4, 1, 14] = 25;
        cups[4, 0, 15] = 2;
        cups[4, 1, 15] = 23;
        cups[4, 0, 16] = 2;
        cups[4, 1, 16] = 25;
        cups[4, 0, 17] = 2;
        cups[4, 1, 17] = 22;
        cups[4, 0, 18] = 2;
        cups[4, 1, 18] = 23;
        cups[4, 0, 19] = 2;
        cups[4, 1, 19] = 22;

        // DD1t's
        cups[5, 0, 0] = 2;
        cups[5, 1, 0] = 28;
        cups[5, 0, 1] = 2;
        cups[5, 1, 1] = 28;
        cups[5, 0, 2] = 1;
        cups[5, 1, 2] = 28;
        cups[5, 0, 3] = 1;
        cups[5, 1, 3] = 28;

        // M7+t's
        cups[6, 0, 0] = 2;
        cups[6, 1, 0] = 32;
        cups[6, 0, 1] = 2;
        cups[6, 1, 1] = 32;
        cups[6, 0, 2] = 2;
        cups[6, 1, 2] = 35;
        cups[6, 0, 3] = 2;
        cups[6, 1, 3] = 31;
        cups[6, 0, 4] = 1;
        cups[6, 1, 4] = 33;
        cups[6, 0, 5] = 1;
        cups[6, 1, 5] = 45;
        cups[6, 0, 6] = 2;
        cups[6, 1, 6] = 45;
        cups[6, 0, 7] = 1;
        cups[6, 1, 7] = 34;
        cups[6, 0, 8] = 1;
        cups[6, 1, 8] = 37;
        cups[6, 0, 9] = 1;
        cups[6, 1, 9] = 38;

        // M6-t's
        cups[7, 0, 0] = 1;
        cups[7, 1, 0] = 41;
        cups[7, 0, 1] = 1;
        cups[7, 1, 1] = 41;
        cups[7, 0, 2] = 1;
        cups[7, 1, 2] = 42;
        cups[7, 0, 3] = 1;
        cups[7, 1, 3] = 42;
        cups[7, 0, 4] = 1;
        cups[7, 1, 4] = 42;
        cups[7, 0, 5] = 1;
        cups[7, 1, 5] = 42;
        cups[7, 0, 6] = 1;
        cups[7, 1, 6] = 42;
        cups[7, 0, 7] = 1;
        cups[7, 1, 7] = 42;
        cups[7, 0, 8] = 1;
        cups[7, 1, 8] = 42;
        cups[7, 0, 9] = 1;
        cups[7, 1, 9] = 42;
        cups[7, 0, 10] = 1;
        cups[7, 1, 10] = 42;
        cups[7, 0, 11] = 1;
        cups[7, 1, 11] = 43;
        cups[7, 0, 12] = 1;
        cups[7, 1, 12] = 43;
        cups[7, 0, 13] = 1;
        cups[7, 1, 13] = 44;
        cups[7, 0, 14] = 1;
        cups[7, 1, 14] = 44;
        cups[7, 0, 15] = 1;
        cups[7, 1, 15] = 44;
        cups[7, 0, 16] = 1;
        cups[7, 1, 16] = 45;
        cups[7, 0, 17] = 1;
        cups[7, 1, 17] = 45;
        cups[7, 0, 18] = 1;
        cups[7, 1, 18] = 46;
        cups[7, 0, 19] = 1;
        cups[7, 1, 19] = 46;
        cups[7, 0, 20] = 1;
        cups[7, 1, 20] = 46;
        cups[7, 0, 21] = 1;
        cups[7, 1, 21] = 46;
        cups[7, 0, 22] = 1;
        cups[7, 1, 22] = 46;
        cups[7, 0, 23] = 1;
        cups[7, 1, 23] = 46;
        cups[7, 0, 24] = 1;
        cups[7, 1, 24] = 46;
        cups[7, 0, 25] = 2;
        cups[7, 1, 25] = 47;
        cups[7, 0, 26] = 1;
        cups[7, 1, 26] = 48;
        cups[7, 0, 27] = 1;
        cups[7, 1, 27] = 40;
        cups[7, 0, 28] = 1;
        cups[7, 1, 28] = 40;
        cups[7, 0, 29] = 1;
        cups[7, 1, 29] = 49;
        cups[7, 0, 30] = 1;
        cups[7, 1, 30] = 49;
        cups[7, 0, 31] = 1;
        cups[7, 1, 31] = 49;
        cups[7, 0, 32] = 2;
        cups[7, 1, 32] = 49;
        cups[7, 0, 33] = 2;
        cups[7, 1, 33] = 39;
        cups[7, 0, 34] = 2;
        cups[7, 1, 34] = 50;

        // CV15t's
        cups[8, 0, 0] = 2;
        cups[8, 1, 0] = 5;
        cups[8, 0, 1] = 2;
        cups[8, 1, 1] = 6;

        // Diligent DD's
        cups[9, 0, 0] = 1;
        cups[9, 1, 0] = 30;
        cups[9, 0, 1] = 2;
        cups[9, 1, 1] = 30;
        cups[9, 0, 2] = 2;
        cups[9, 1, 2] = 30;

        // DE1t's
        cups[10, 0, 0] = 1;
        cups[10, 1, 0] = 29;
        cups[10, 0, 1] = 2;
        cups[10, 1, 1] = 29;
        cups[10, 0, 2] = 2;
        cups[10, 1, 2] = 29;
        cups[10, 0, 3] = 2;
        cups[10, 1, 3] = 29;
        cups[10, 0, 4] = 2;
        cups[10, 1, 4] = 29;

        // TDC Tokens

        // -3
        cups[11, 0, 0] = 1;
        cups[11, 1, 0] = 2;
        cups[11, 0, 1] = 1;
        cups[11, 1, 1] = 2;

        // -2
        cups[11, 0, 2] = 1;
        cups[11, 1, 2] = 3;
        cups[11, 0, 3] = 1;
        cups[11, 1, 3] = 3;
        cups[11, 0, 4] = 1;
        cups[11, 1, 4] = 3;
        cups[11, 0, 5] = 1;
        cups[11, 1, 5] = 3;

        // -1
        cups[11, 0, 6] = 1;
        cups[11, 1, 6] = 4;
        cups[11, 0, 7] = 1;
        cups[11, 1, 7] = 4;
        cups[11, 0, 8] = 1;
        cups[11, 1, 8] = 4;
        cups[11, 0, 9] = 1;
        cups[11, 1, 9] = 4;

        // 0
        cups[11, 0, 10] = 1;
        cups[11, 1, 10] = 5;
        cups[11, 0, 11] = 1;
        cups[11, 1, 11] = 5;
        cups[11, 0, 12] = 1;
        cups[11, 1, 12] = 5;
        cups[11, 0, 13] = 1;
        cups[11, 1, 13] = 5;

        // +1
        cups[11, 0, 14] = 1;
        cups[11, 1, 14] = 6;
        cups[11, 0, 15] = 1;
        cups[11, 1, 15] = 6;
        cups[11, 0, 16] = 1;
        cups[11, 1, 16] = 6;
        cups[11, 0, 17] = 1;
        cups[11, 1, 17] = 6;

        // +2
        cups[11, 0, 18] = 1;
        cups[11, 1, 18] = 7;
        cups[11, 0, 19] = 1;
        cups[11, 1, 19] = 7;
        cups[11, 0, 20] = 1;
        cups[11, 1, 20] = 7;
        cups[11, 0, 21] = 1;
        cups[11, 1, 21] = 7;

        // -3
        cups[11, 0, 22] = 1;
        cups[11, 1, 22] = 8;
        cups[11, 0, 23] = 1;
        cups[11, 1, 23] = 8;

        if (warPeriod == 1)
        {
            // Cup A

            // Combat Event
            cups[0, 0, 0] = 1;
            cups[0, 1, 0] = 1;

            // H6
            cups[0, 0, 1] = 2;
            cups[0, 1, 1] = 3;

            // DD2t's
            pullFromCupAndStore(4, cups, 2, 0, 2);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 0, 4);

            // M7+t
            pullFromCupAndStore(6, cups, 1, 0, 5);

            // M6-t's
            pullFromCupAndStore(7, cups, 16, 0, 6);

            // Cup B

            // Combat Event
            cups[1, 0, 0] = 1;
            cups[1, 1, 0] = 1;

            // H8
            cups[1, 0, 1] = 2;
            cups[1, 1, 1] = 2;

            // Izumo
            cups[1, 0, 2] = 2;
            cups[1, 1, 2] = 18;

            // DD2t's
            pullFromCupAndStore(4, cups, 4, 1, 3);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 1, 7);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 1, 8);

            // M6-t's
            pullFromCupAndStore(7, cups, 7, 1, 11);

            // Cup C

            // Combat Event
            cups[2, 0, 0] = 1;
            cups[2, 1, 0] = 1;

            // Asahi
            cups[2, 0, 1] = 2;
            cups[2, 1, 1] = 17;

            // CA9t
            cups[2, 0, 2] = 2;
            cups[2, 1, 2] = 20;

            // CL5ts
            cups[2, 0, 3] = 2;
            cups[2, 1, 3] = 21;
            cups[2, 0, 4] = 2;
            cups[2, 1, 4] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 6, 2, 5);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 2, 11);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 2, 12);

            // M6-t's
            pullFromCupAndStore(7, cups, 6, 2, 15);

            // Cup D

            // Combat Event
            cups[3, 0, 0] = 1;
            cups[3, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 2, 3, 1);

            // CV10t
            cups[3, 0, 3] = 2;
            cups[3, 1, 3] = 4;

            // Shokaku
            cups[3, 0, 4] = 2;
            cups[3, 1, 4] = 8;

            // BB32t's
            cups[3, 0, 5] = 2;
            cups[3, 1, 5] = 11;
            cups[3, 0, 6] = 2;
            cups[3, 1, 6] = 11;

            // BB40t
            cups[3, 0, 7] = 2;
            cups[3, 1, 7] = 12;

            // BB36t
            cups[3, 0, 8] = 2;
            cups[3, 1, 8] = 13;

            // BB35t
            cups[3, 0, 9] = 2;
            cups[3, 1, 9] = 15;

            // CA15t
            cups[3, 0, 10] = 2;
            cups[3, 1, 10] = 19;

            // CA9t
            cups[3, 0, 11] = 2;
            cups[3, 1, 11] = 20;

            // CL5ts
            cups[3, 0, 12] = 2;
            cups[3, 1, 12] = 21;
            cups[3, 0, 13] = 2;
            cups[3, 1, 13] = 21;
            cups[3, 0, 14] = 2;
            cups[3, 1, 14] = 21;
            cups[3, 0, 15] = 2;
            cups[3, 1, 15] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 8, 3, 16);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 3, 24);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 3, 25);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 3, 26);

            // M6-t's
            pullFromCupAndStore(7, cups, 6, 3, 29);
        }
        else if (warPeriod == 2)
        {
            // Cup A

            // Combat Event
            cups[0, 0, 0] = 1;
            cups[0, 1, 0] = 1;

            // H6
            cups[0, 0, 1] = 2;
            cups[0, 1, 1] = 3;

            // DD2t's
            pullFromCupAndStore(4, cups, 2, 0, 2);

            // DD1t
            pullFromCupAndStore(5, cups, 2, 0, 4);

            // M7+t
            pullFromCupAndStore(6, cups, 1, 0, 6);

            // M6-t's
            pullFromCupAndStore(7, cups, 16, 0, 7);

            // Cup B

            // Combat Event
            cups[1, 0, 0] = 1;
            cups[1, 1, 0] = 1;

            // H8
            cups[1, 0, 1] = 2;
            cups[1, 1, 1] = 2;

            // CV10t
            cups[1, 0, 2] = 2;
            cups[1, 1, 2] = 4;

            // Izumo
            cups[1, 0, 3] = 2;
            cups[1, 1, 3] = 18;

            // DD2t's
            pullFromCupAndStore(4, cups, 6, 1, 4);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 1, 10);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 1, 11);

            // M6-t's
            pullFromCupAndStore(7, cups, 10, 1, 14);

            // Cup C

            // Combat Event
            cups[2, 0, 0] = 1;
            cups[2, 1, 0] = 1;

            // BB32t's
            cups[2, 0, 1] = 2;
            cups[2, 1, 1] = 11;

            // Asahi
            cups[2, 0, 2] = 2;
            cups[2, 1, 2] = 17;

            // CA9t
            cups[2, 0, 3] = 2;
            cups[2, 1, 3] = 20;

            // CL5ts
            cups[2, 0, 4] = 2;
            cups[2, 1, 4] = 21;
            cups[2, 0, 5] = 2;
            cups[2, 1, 5] = 21;
            cups[2, 0, 6] = 2;
            cups[2, 1, 6] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 6, 2, 7);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 2, 13);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 3, 14);

            // M7+t
            pullFromCupAndStore(6, cups, 4, 2, 15);

            // M6-t's
            pullFromCupAndStore(7, cups, 6, 2, 19);

            // Cup D

            // Combat Event
            cups[3, 0, 0] = 1;
            cups[3, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 2, 3, 1);

            // Shokaku
            cups[3, 0, 3] = 2;
            cups[3, 1, 3] = 8;

            // BB32t's
            cups[3, 0, 4] = 2;
            cups[3, 1, 4] = 11;

            // BB40t
            cups[3, 0, 5] = 2;
            cups[3, 1, 5] = 12;

            // BB36t
            cups[3, 0, 6] = 2;
            cups[3, 1, 6] = 13;

            // BB35t
            cups[3, 0, 7] = 2;
            cups[3, 1, 7] = 15;

            // Yamato
            cups[3, 0, 8] = 2;
            cups[3, 1, 8] = 16;

            // CA15t
            cups[3, 0, 9] = 2;
            cups[3, 1, 9] = 19;

            // CA9t
            cups[3, 0, 10] = 2;
            cups[3, 1, 10] = 20;

            // CL5ts
            cups[3, 0, 11] = 2;
            cups[3, 1, 11] = 21;
            cups[3, 0, 12] = 2;
            cups[3, 1, 12] = 21;
            cups[3, 0, 13] = 2;
            cups[3, 1, 13] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 6, 3, 14);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 3, 20);

            // M7+t
            pullFromCupAndStore(6, cups, 2, 3, 21);

            // M6-t's
            pullFromCupAndStore(7, cups, 3, 3, 23);
        }
        else if (warPeriod == 3)
        {
            // Cup A

            // Combat Event
            cups[0, 0, 0] = 1;
            cups[0, 1, 0] = 1;

            // H6
            cups[0, 0, 1] = 2;
            cups[0, 1, 1] = 3;

            // CL5ts
            cups[0, 0, 2] = 2;
            cups[0, 1, 2] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 3, 0, 3);

            // DD1t
            pullFromCupAndStore(5, cups, 2, 0, 6);

            // DE1t
            pullFromCupAndStore(10, cups, 1, 0, 8);

            // M7+t
            pullFromCupAndStore(6, cups, 1, 0, 9);

            // M6-t's
            pullFromCupAndStore(7, cups, 10, 0, 10);

            // Cup B

            // Combat Event
            cups[1, 0, 0] = 1;
            cups[1, 1, 0] = 1;

            // H8
            cups[1, 0, 1] = 2;
            cups[1, 1, 1] = 2;

            // CV10t
            cups[1, 0, 2] = 2;
            cups[1, 1, 2] = 4;

            // CL5ts
            cups[1, 0, 3] = 2;
            cups[1, 1, 3] = 21;
            cups[1, 0, 4] = 2;
            cups[1, 1, 4] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 5, 1, 5);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 1, 10);

            // DE1t
            pullFromCupAndStore(10, cups, 2, 1, 11);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 1, 13);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 1, 14);

            // M6-t's
            pullFromCupAndStore(7, cups, 8, 1, 17);

            // Cup C

            // Combat Event
            cups[2, 0, 0] = 1;
            cups[2, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 1, 2, 1);

            // BB32t's
            cups[2, 0, 2] = 2;
            cups[2, 1, 2] = 11;

            // CA9t
            cups[2, 0, 3] = 2;
            cups[2, 1, 3] = 20;

            // CL5ts
            cups[2, 0, 4] = 2;
            cups[2, 1, 4] = 21;
            cups[2, 0, 5] = 2;
            cups[2, 1, 5] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 5, 2, 6);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 2, 11);

            // DE1t
            pullFromCupAndStore(10, cups, 1, 2, 12);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 2, 13);

            // M7+t
            pullFromCupAndStore(6, cups, 4, 2, 14);

            // M6-t's
            pullFromCupAndStore(7, cups, 6, 2, 18);

            // Cup D

            // Combat Event
            cups[3, 0, 0] = 1;
            cups[3, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 1, 3, 1);

            // Shokaku
            cups[3, 0, 2] = 2;
            cups[3, 1, 2] = 8;

            // Taiho
            cups[3, 0, 3] = 2;
            cups[3, 1, 3] = 9;

            // BB32t's
            cups[3, 0, 4] = 2;
            cups[3, 1, 4] = 11;

            // BB40t
            cups[3, 0, 5] = 2;
            cups[3, 1, 5] = 12;

            // BB35t
            cups[3, 0, 6] = 2;
            cups[3, 1, 6] = 15;

            // Yamato
            cups[3, 0, 7] = 2;
            cups[3, 1, 7] = 16;

            // CA15t
            cups[3, 0, 8] = 2;
            cups[3, 1, 8] = 19;

            // CA9t
            cups[3, 0, 9] = 2;
            cups[3, 1, 9] = 20;

            // CL5ts
            cups[3, 0, 10] = 2;
            cups[3, 1, 10] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 3, 3, 11);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 3, 14);

            // M7+t
            pullFromCupAndStore(6, cups, 2, 3, 15);

            // M6-t's
            pullFromCupAndStore(7, cups, 4, 3, 17);
        }
        else if (warPeriod == 4)
        {
          // Cup A

            // Combat Event
            cups[0, 0, 0] = 1;
            cups[0, 1, 0] = 1;

            // H6
            cups[0, 0, 1] = 2;
            cups[0, 1, 1] = 3;

            // CL5ts
            cups[0, 0, 2] = 2;
            cups[0, 1, 2] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 1, 0, 3);

            // DD1t
            pullFromCupAndStore(5, cups, 2, 0, 4);

            // DE1t
            pullFromCupAndStore(10, cups, 1, 0, 6);

            // M7+t
            pullFromCupAndStore(6, cups, 1, 0, 7);

            // M6-t's
            pullFromCupAndStore(7, cups, 10, 0, 8);

            // Cup B

            // Combat Event
            cups[1, 0, 0] = 1;
            cups[1, 1, 0] = 1;

            // H8
            cups[1, 0, 1] = 2;
            cups[1, 1, 1] = 2;

            // CV10t
            cups[1, 0, 2] = 2;
            cups[1, 1, 2] = 4;

            // CL5ts
            cups[1, 0, 3] = 2;
            cups[1, 1, 3] = 21;
            cups[1, 0, 4] = 2;
            cups[1, 1, 4] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 2, 1, 5);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 1, 7);

            // DE1t
            pullFromCupAndStore(10, cups, 2, 1, 8);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 1, 10);

            // M7+t
            pullFromCupAndStore(6, cups, 3, 1, 11);

            // M6-t's
            pullFromCupAndStore(7, cups, 8, 1, 14);

            // Cup C

            // Combat Event
            cups[2, 0, 0] = 1;
            cups[2, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 1, 2, 1);

            // BB32t's
            cups[2, 0, 2] = 2;
            cups[2, 1, 2] = 11;

            // CL5ts
            cups[2, 0, 3] = 2;
            cups[2, 1, 3] = 21;
            cups[2, 0, 4] = 2;
            cups[2, 1, 4] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 3, 2, 5);

            // DD1t
            pullFromCupAndStore(5, cups, 1, 2, 8);

            // DE1t
            pullFromCupAndStore(10, cups, 2, 2, 9);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 2, 11);

            // M7+t
            pullFromCupAndStore(6, cups, 4, 3, 12);

            // M6-t's
            pullFromCupAndStore(7, cups, 7, 2, 15);

            // Cup D

            // Combat Event
            cups[3, 0, 0] = 1;
            cups[3, 1, 0] = 1;

            // CV15t's
            pullFromCupAndStore(8, cups, 1, 3, 1);

            // Shokaku
            cups[3, 0, 2] = 2;
            cups[3, 1, 2] = 8;

            // Taiho
            cups[3, 0, 3] = 2;
            cups[3, 1, 3] = 9;

            // Shinano
            cups[3, 0, 4] = 2;
            cups[3, 1, 4] = 10;

            // BB40t
            cups[3, 0, 5] = 2;
            cups[3, 1, 5] = 12;

            // BV36t
            cups[3, 0, 6] = 2;
            cups[3, 1, 6] = 14;

            // Yamato
            cups[3, 0, 7] = 2;
            cups[3, 1, 7] = 16;

            // CA15t
            cups[3, 0, 8] = 2;
            cups[3, 1, 8] = 19;

            // CA9t
            cups[3, 0, 9] = 2;
            cups[3, 1, 9] = 20;

            // CL5ts
            cups[3, 0, 10] = 2;
            cups[3, 1, 10] = 21;

            // DD2t's
            pullFromCupAndStore(4, cups, 2, 3, 11);

            // Dilligent DD
            pullFromCupAndStore(9, cups, 1, 3, 13);

            // M7+t
            pullFromCupAndStore(6, cups, 2, 3, 14);

            // M6-t's
            pullFromCupAndStore(7, cups, 1, 3, 16);
        }
    }

    public static int pullFromCup(int cupIndex, int[,,] cups)
    {
        int len = cups.GetLength(2);
        int targetsLeft = 0;

        for (int i = 0; i < len; i++)
        {
            if (cups[cupIndex, 0, i] > 0)
                targetsLeft++;
        }

        if (targetsLeft <= 0)
            return 0;

        int choice = Random.Range(0, targetsLeft);
        int count = 0;
        for (int i = 0; i < len; i++)
        {
            if (cups[cupIndex, 0, i] > 0)
            {
                if (count == choice)
                {
                    return i;
                }
                else
                {
                    count++;
                }
            }
        }
        return 0;
    }

    public static void pullFromCupAndStore(int cupIndex, int[,,] cups, int howMany, int toCup, int inCupIndex)
    {
        int len = cups.GetLength(2);
        int targetsLeft = 0;
        int foundIndex = 0;

        for (int counter = 0; counter < howMany; counter++)
        {
            targetsLeft = 0;
            foundIndex = 0;

            for (int i = 0; i < len; i++)
            {
                if (cups[cupIndex, 0, i] > 0)
                    targetsLeft++;
            }

            if (targetsLeft <= 0)
                return;

            int choice = Random.Range(0, targetsLeft);
            int count = 0;
            for (int i = 0; i < len; i++)
            {
                if (cups[cupIndex, 0, i] > 0)
                {
                    if (count == choice)
                    {
                        foundIndex = i;
                        break;
                    }
                    else {
                        count++;
                    }
                }
            }

            cups[toCup, 0, inCupIndex + counter] = cups[cupIndex, 0, foundIndex];
            cups[toCup, 1, inCupIndex + counter] = cups[cupIndex, 1, foundIndex];
            cups[cupIndex, 0, foundIndex] = 0;
            cups[cupIndex, 1, foundIndex] = 0;
        }
    }

    public static void resetBoard()
    {
        // pull targets from cups
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                targetBackIndices[i, j] = 0;
                targetFrontIndices[i, j] = 0;
                if (targets[i, j])
                    targets[i, j].front = false;
                tdcTextureIndices[i, j] = 0;
                tdcRolledIndices[i, j] = 0;
            }
        }
    }

    // Use this for initialization
    public static void LoadTdcTargets()
    {
        if (!targetsRolled)
        {
            // Cups:
            // 0 = Cup A
            // 1 = Cub B
            // 2 = Cup C
            // 3 = Cup D
            // 4 = DD2t's
            // 5 = DD1t's
            // 6 = M7+t's
            // 7 = M6-t's
            // 8 = CV15t's
            // 9 = Dilligent DD
            // 10 = DE1t's
            // 11 = TDC Tokens
            int[,,] cups = new int[12, 2, 35];

            fillCups(cups);
            setupColumns();
            resetBoard();

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    tdcTextureIndices[i, j] = 0;
                }
            }

            // pull targets from cups
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < targetsPerColumn[i]; j++)
                {
                    int cupTargetIndex = pullFromCup(i, cups);
                    targetBackIndices[i, j] = cups[i, 0, cupTargetIndex];
                    targetFrontIndices[i, j] = cups[i, 1, cupTargetIndex];
                    cups[i, 0, cupTargetIndex] = 0;
                    cups[i, 1, cupTargetIndex] = 0;

                    cupTargetIndex = pullFromCup(11, cups);
                    tdcTextureIndices[i, j] = 0;
                    tdcRolledIndices[i, j] = cups[11, 1, cupTargetIndex];
                    cups[11, 0, cupTargetIndex] = 0;
                    cups[11, 1, cupTargetIndex] = 0;
                }
            }

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (targets[i, j])
                        targets[i, j].loadTexture();
                }
            }

            targetsRolled = true;
            Grid.resetTargetsButton.GetComponent<SpriteRenderer>().sprite = Grid.resetTargetsButton.textures[1];
        }
    }

    public static int[] tdcGridCoordinates(Tdc tdc)
    {
        int[] coords = new int[2];
        coords[0] = -1;
        coords[1] = -1;

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (tdc == tdcs[i, j])
                {
                    coords[0] = i;
                    coords[1] = j;
                }
            }
        }
        return coords;
    }

    public static int[] targetGridCoordinates(Target target)
    {
        int[] coords = new int[2];
        coords[0] = -1;
        coords[1] = -1;

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (target == targets[i, j])
                {
                    coords[0] = i;
                    coords[1] = j;
                }
            }
        }
        return coords;
    }

    public static int tdcCurrentTexture(Tdc tdc)
    {
        int[] coords = tdcGridCoordinates(tdc);
        if (coords[0] == -1 || coords[1] == -1)
            return 0;

        return tdcTextureIndices[coords[0], coords[1]];
    }

    public static int tdcFlippedTexture(Tdc tdc)
    {
        int[] coords = tdcGridCoordinates(tdc);
        if (coords[0] == -1 || coords[1] == -1)
            return 0;

        if (tdcRolledIndices[coords[0], coords[1]] > 0)
        {
            Grid.resetTdcsButton.GetComponent<SpriteRenderer>().sprite = Grid.resetTdcsButton.textures[1];
            if (tdcTextureIndices[coords[0], coords[1]] == 0)
                tdcTextureIndices[coords[0], coords[1]] = 1;
            else if (tdcTextureIndices[coords[0], coords[1]] == 1)
                tdcTextureIndices[coords[0], coords[1]] = tdcRolledIndices[coords[0], coords[1]];
            else if (tdcTextureIndices[coords[0], coords[1]] > 0)
                tdcTextureIndices[coords[0], coords[1]] = 1;
            return tdcTextureIndices[coords[0], coords[1]];
        }
        else
            return 0;
    }

    public static int tdcShowTexture(Tdc tdc)
    {
        int[] coords = tdcGridCoordinates(tdc);
        if (coords[0] == -1 || coords[1] == -1)
            return 0;

        if ((tdcTextureIndices[coords[0], coords[1]] == 0) && (tdcRolledIndices[coords[0], coords[1]] > 0))
        {
            tdcTextureIndices[coords[0], coords[1]] = 1;
            Grid.resetTdcsButton.GetComponent<SpriteRenderer>().sprite = Grid.resetTdcsButton.textures[1];
        }
        return tdcTextureIndices[coords[0], coords[1]];
    }

    public static int targetCurrentTexture(Target target)
    {
        int[] coords = targetGridCoordinates(target);
        if (coords[0] == -1 || coords[1] == -1)
            return 0;

        if (target.front)
            return targetFrontIndices[coords[0], coords[1]];
        else
            return targetBackIndices[coords[0], coords[1]];
    }

    public static void convoySearch()
    {
        int ultraBonus = 0;

        if (Grid.ultra.on)
            ultraBonus = 1;

        for (int i = 0; i < 4; i++)
        {
            if (columnData[searchRow, searchCol][i] > 0)
                targetsPerColumn[i] = columnData[searchRow, searchCol][i] + ultraBonus;
            else
                targetsPerColumn[i] = columnData[searchRow, searchCol][i];
        }
    }

    public static void setupColumns()
    {
        columnData[0, 0] = new int[4] { 2, 1, 0, 0 };
        columnData[0, 1] = new int[4] { 3, 2, 0, 0 };
        columnData[0, 2] = new int[4] { 1, 2, 2, 2 };
        columnData[1, 0] = new int[4] { 3, 2, 0, 0 };
        columnData[1, 1] = new int[4] { 4, 3, 2, 0 };
        columnData[1, 2] = new int[4] { 1, 2, 3, 3 };
        columnData[2, 0] = new int[4] { 4, 3, 0, 0 };
        columnData[2, 1] = new int[4] { 5, 4, 3, 2 };
        columnData[2, 2] = new int[4] { 2, 3, 3, 4 };
        columnData[3, 0] = new int[4] { 5, 3, 4, 0 };
        columnData[3, 1] = new int[4] { 5, 4, 3, 2 };
        columnData[3, 2] = new int[4] { 3, 3, 4, 5 };
    }

    public static void loadSearchIndices()
    {
        if (!searchIndicesLoaded)
        {
            searchIndices[0, 0] = 0;
            searchIndices[1, 0] = 1;
            searchIndices[2, 0] = 2;
            searchIndices[3, 0] = 3;
            searchIndices[0, 1] = 4;
            searchIndices[1, 1] = 5;
            searchIndices[2, 1] = 6;
            searchIndices[3, 1] = 7;
            searchIndices[0, 2] = 8;
            searchIndices[1, 2] = 9;
            searchIndices[2, 2] = 10;
            searchIndices[3, 2] = 11;
        }
    }

    public static void changeWarPeriod(WarPeriod warPeriodMarker)
    {
        for (int i = 0; i < 4; i++)
        {
            if (warPeriodMarker == Grid.warPeriods[i])
            {
                if (warPeriod != (i + 1))
                {
                    warPeriod = (i + 1);
                    Grid.warPeriods[i].GetComponent<SpriteRenderer>().sprite = Grid.warPeriods[i].textures[1];
                    if (targetsRolled)
                    {
                        setupColumns();
                        convoySearch();
                        targetsRolled = false;
                        LoadTdcTargets();
                    }
                }
            }
            else {
                Grid.warPeriods[i].GetComponent<SpriteRenderer>().sprite = Grid.warPeriods[i].textures[0];
            }
        }
    }

    public static void changeSearch(Search search = null)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (search == Grid.searches[i, j])
                {
                    Grid.searches[i, j].active = true;
                    Grid.searches[i, j].GetComponent<SpriteRenderer>().sprite = Grid.searches[i, j].activeTextures[searchIndices[i, j]];
                    searchRow = i;
                    searchCol = j;
                    setupColumns();
                    convoySearch();
                    targetsRolled = false;
                    LoadTdcTargets();
                }
                else {
                    if (Grid.searches[i, j].active)
                    {
                        Grid.searches[i, j].active = false;
                        Grid.searches[i, j].GetComponent<SpriteRenderer>().sprite = Grid.searches[i, j].dimTextures[searchIndices[i, j]];
                    }
                }
            }
        }
    }

    public static void changeUltra()
    {
        if (targetsRolled)
        {
            targetsRolled = false;
            convoySearch();
            LoadTdcTargets();
        }
    }

    public static void resetTargets()
    {
        resetBoard();
        searchRow = 0;
        searchCol = 0;
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (targets[i, j])
                {
                    targets[i, j].loadTexture();
                    tdcs[i, j].loadTexture();
                }
            }
        }
        changeSearch();

        targetsRolled = false;
    }

    public static void resetTdcs()
    {
        int[,,] cups = new int[12, 2, 35];

        fillCups(cups);
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                tdcTextureIndices[i, j] = 0;
            }
        }

        // pull targets from cups
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < targetsPerColumn[i]; j++)
            {
                int cupTargetIndex = pullFromCup(11, cups);
                tdcTextureIndices[i, j] = 0;
                tdcRolledIndices[i, j] = cups[11, 1, cupTargetIndex];
                cups[11, 0, cupTargetIndex] = 0;
                cups[11, 1, cupTargetIndex] = 0;

                tdcs[i, j].loadTexture();
            }
        }

        Grid.resetTdcsButton.GetComponent<SpriteRenderer>().sprite = Grid.resetTdcsButton.textures[0];
    }
}