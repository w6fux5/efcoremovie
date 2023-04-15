using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Entities.Function;

public static class Scalars
{

    public static void RegisterFunctoins(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDbFunction(() => InvoiceDetailSum(0));  // 隨便帶入一個參數，只是一個 placeholder
        modelBuilder.HasDbFunction(() => InvoiceDetailAverage(0));
    }

    public static int InvoiceDetailSum(int invoiceId)
    {
        return 0; // 隨便 return 一個值，只是一個 placeholder
    }

    public static decimal InvoiceDetailAverage(int invoicdId)
    {
        return 0;
    }

}


