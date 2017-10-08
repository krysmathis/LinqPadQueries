<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>EPPlus</NuGetReference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>OfficeOpenXml</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
</Query>

void Main()
{
	try{
		
		DataTable dt = GetDataTableFromExcel(@"C:\Users\krys\Documents\Test.xlsx",true).Dump();
		
		//here if we need to modify the dataset so that it conforms to a certain type
		DataTable dtCloned = dt.Clone();
		dtCloned.Columns[0].DataType = typeof(string);
		foreach (DataRow row in dt.Rows) 
		{
			dtCloned.ImportRow(row);
		}
		dt.Dispose();

		string newPath = @"C:\Users\krys\Documents\Test_Output.xlsx";
		
		try{ File.Delete(newPath);}
		catch (IOException) { Console.WriteLine ("File in use. Cannot delete."); }
		
		FileInfo newFile = new FileInfo(newPath);
		//export the file
		using (ExcelPackage pck = new ExcelPackage(newFile))
			{
				
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("UPLOAD");
				ws.Cells["A1"].LoadFromDataTable(dtCloned, true);
				pck.Save();
				
			}
		
		//Validation of sheet
		foreach (DataRow r in dtCloned.Rows){
			//for each row:
			if ((string)r[1]=="B"){ Console.WriteLine (r[1]);}

		}
		
		//TODO: could keep a log of all the files that it review and writes that somewhere
		//TODO: be able to add validation logic dynamically, say from text file
		
		Console.WriteLine ("Successful");
	}
	catch (FileNotFoundException)
	{
		Console.WriteLine ("Could not find the file.");
	}
	catch (IOException)
	{
		Console.WriteLine ("The file is open, close it and retry.");
	}
	
	
}



   
   public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
{
    using (var pck = new OfficeOpenXml.ExcelPackage())
    {
        using (var stream = File.OpenRead(path))
        {
            pck.Load(stream);
        }
        var ws = pck.Workbook.Worksheets.First();  
        DataTable tbl = new DataTable();
        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
        {
            tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
        }
        var startRow = hasHeader ? 2 : 1;
        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
        {
            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
            DataRow row = tbl.Rows.Add();
            foreach (var cell in wsRow)
            {
                row[cell.Start.Column - 1] = cell.Text;
            }
        }
        return tbl;
    }
}