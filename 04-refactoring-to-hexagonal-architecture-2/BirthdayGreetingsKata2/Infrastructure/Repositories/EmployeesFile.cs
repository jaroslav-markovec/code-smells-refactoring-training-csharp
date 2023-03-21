using System;
using System.Collections.Generic;
using System.IO;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Infrastructure.Repositories;

public class EmployeesFile
{
    private readonly StreamReader _streamReader;

    private EmployeesFile(StreamReader streamReader) {
        _streamReader = streamReader;
    }

    public static EmployeesFile LoadFrom(String path) {
        return new EmployeesFile(FileReader.ReadSkippingHeader(path));
    }

    public List<Employee> ExtractEmployees() {
        List<Employee> employees = new List<Employee>();
        while (_streamReader.ReadLine() is { } line) {
            EmployeeCsvRepresentation representation = new EmployeeCsvRepresentation(line);
            employees.Add(representation.ConvertToEmployee());
        }
        _streamReader.Close();
        return employees;
    }

    private class EmployeeCsvRepresentation {
        private readonly String _content;
        private readonly String[] _tokens;

        public EmployeeCsvRepresentation(String content) {
            _content = content;
            _tokens = content.Split(", ");
        }

        public Employee ConvertToEmployee() {
            return new Employee(FirstName(), LastName(), BirthDate(), Email());
        }

        private String LastName() {
            return _tokens[0];
        }

        private String Email() {
            return _tokens[3];
        }

        private String FirstName() {
            return _tokens[1];
        }

        private OurDate BirthDate() {
            try {
                return new DateRepresentation(DateAsString()).ToDate();
            } catch (FormatException exception) {
                throw new CannotReadEmployeesException(
                    $"Badly formatted employee birth date in: '{_content}'",
                    exception
                );
            }
        }

        private String DateAsString() {
            return _tokens[2];
        }
    }

    private static class FileReader {
        public static StreamReader ReadSkippingHeader(String path) {
            try {
                return SkipHeader(ReadFile(path));
            } catch (IOException exception) {
                throw new CannotReadEmployeesException(
                    $"cannot loadFrom file = '{path}'",
                    exception
                );
            }
        }

        private static StreamReader ReadFile(string path) {
            StreamReader reader = new StreamReader(path);
            return reader;
        }

        private static StreamReader SkipHeader(StreamReader stream) {
            stream.ReadLine();
            return stream;
        }
    }
}