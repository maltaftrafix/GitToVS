using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceChecker.BO
{
    class CommitBO
    {
        public class Author
        {
            public object NodeId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Date { get; set; }
        }

        public class Committer
        {
            public object NodeId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Date { get; set; }
        }

        public class Tree
        {
            public object NodeId { get; set; }
            public string Url { get; set; }
            public object Label { get; set; }
            public object Ref { get; set; }
            public string Sha { get; set; }
            public object User { get; set; }
            public object Repository { get; set; }
        }

        public class Reason
        {
            public string StringValue { get; set; }
            public int Value { get; set; }
        }

        public class Verification
        {
            public bool Verified { get; set; }
            public Reason Reason { get; set; }
            public object Signature { get; set; }
            public object Payload { get; set; }
        }

        public class Commit
        {
            public string Message { get; set; }
            public Author Author { get; set; }
            public Committer Committer { get; set; }
            public Tree Tree { get; set; }
            public object Parents { get; set; }
            public int CommentCount { get; set; }
            public Verification Verification { get; set; }
            public object NodeId { get; set; }
            public string Url { get; set; }
            public object Label { get; set; }
            public object Ref { get; set; }
            public object Sha { get; set; }
            public object User { get; set; }
            public object Repository { get; set; }
        }

        public class Parent
        {
            public object NodeId { get; set; }
            public string Url { get; set; }
            public object Label { get; set; }
            public object Ref { get; set; }
            public string Sha { get; set; }
            public object User { get; set; }
            public object Repository { get; set; }
        }

        public class RootObject
        {
            public object Author { get; set; }
            public string CommentsUrl { get; set; }
            public Commit Commit { get; set; }
            public object Committer { get; set; }
            public string HtmlUrl { get; set; }
            public object Stats { get; set; }
            public List<Parent> Parents { get; set; }
            public object Files { get; set; }
            public string NodeId { get; set; }
            public string Url { get; set; }
            public object Label { get; set; }
            public object Ref { get; set; }
            public string Sha { get; set; }
            public object User { get; set; }
            public object Repository { get; set; }
        }
    }
}
