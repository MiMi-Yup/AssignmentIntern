using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    #region Structure
    public class Branch
    {
        List<Branch> branches;

        public Branch()
        {
            branches = new List<Branch>();
        }

        //add some operations
        public void AddItem(Branch item)
        {
            branches.Add(item);
        }

        public int CalDepthBranch()
        {
            return CalDepthSubBranch(this);
        }

        private int CalDepthSubBranch(Branch branch)
        {
            if (branch == null) return 0;
            int maxDepth = 0;
            foreach (var item in branch.branches)
            {
                maxDepth = Math.Max(maxDepth, CalDepthSubBranch(item));
            }

            return maxDepth + 1;
        }
    }
    #endregion

    #region Builder
    public interface IBranchBuilder
    {
        IBranchBuilder AddItem(Branch item);
        Branch Build();
    }

    public class BranchBuilder : IBranchBuilder
    {
        Branch root;

        public BranchBuilder()
        {
            Reset();
        }

        private void Reset()
        {
            root = new Branch();
        }

        public IBranchBuilder AddItem(Branch item)
        {
            root.AddItem(item);
            return this;
        }

        public Branch Build()
        {
            Branch temp = root; ;
            Reset();
            return temp;
        }
    }
    #endregion

    internal class Program
    {
        static Branch CreateStructure()
        {
            IBranchBuilder builder = new BranchBuilder();
            builder.AddItem(
                new BranchBuilder()
                    .AddItem(new Branch())
                .Build());
            builder.AddItem(
                new BranchBuilder()
                    .AddItem(
                        new BranchBuilder()
                            .AddItem(new Branch())
                            .Build())
                    .AddItem(
                        new BranchBuilder().
                            AddItem(
                                new BranchBuilder()
                                    .AddItem(new Branch())
                                    .Build())
                            .AddItem(new Branch())
                            .Build())
                    .AddItem(new Branch())
                    .Build());
            return builder.Build();
        }

        static void Main(string[] args)
        {
            Branch branch = CreateStructure();
            int depthOfBranch = branch.CalDepthBranch();
            Console.WriteLine(depthOfBranch);
        }
    }
}
