Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Module Module1
    Dim Key As String = "!hX7W#i]3:nh<Fj>+{[,.MvIRF=Kk!+Sm8DBFEqi@9dU/\iLS}UR;C)]LZ;fm?>"
    Dim i As Integer = 0
    Dim stfi As ArrayList = New ArrayList
    Sub Main()
        Dim filename As String = "filter.csv"
        Dim fields As String()
        Dim delimiter As String = ","

        Using parser As New TextFieldParser(filename)
            parser.SetDelimiters(delimiter)
            While Not parser.EndOfData
                ' Read in the fields for the current line
                fields = parser.ReadFields()

                ' Add code here to use data in fields variable.
                Dim bf As New BinaryFormatter()
                For Each Word As String In fields
                    stfi.Add(Crypto.EncryptTripleDES(Word, Key))
                    Console.WriteLine(Word & " | " & Crypto.EncryptTripleDES(Word, Key) & " | " & Crypto.DecryptTripleDES(stfi(i), Key))
                    i = i + 1
                Next
                Using str As FileStream = File.Create("filter.db")
                    bf.Serialize(str, stfi)
                    'Console.ReadLine()
                End Using
            End While
        End Using

        Console.WriteLine("--- DONE ---")
        Console.WriteLine(Key)
        Console.WriteLine(Crypto.ScrambleKey(Key))
        Console.ReadLine()
    End Sub
End Module
