using investition;

int[,] table =
{
    {8,  10,  12,  11 },
    {16, 20,  21,  23 },
    {25, 28,  27,  30 },
    {36, 40,  38,  37, },
    {44, 48  ,50  ,51 },
    {62 ,62  ,63  ,63 }
};

int[] step = { 20, 40, 60, 80, 100, 120 };
int[] companies = { 1, 2, 3, 4 };

Investition investition = new Investition();
investition.MainMethod(table, step, companies);
