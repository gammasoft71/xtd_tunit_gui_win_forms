﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunit {
  public class Test {
    public Test(TestFixture testFixture, string name) {
      this.testFixture = testFixture;
      this.Name = name;
      this.Reset();
    }

    public TimeSpan Duration { get; private set; }

    public string Name { get; private set; }

    public TestStatus Status { get; set; }

    public string StackTrace { get; private set; }

    public string[] Messages { get; private set; }

    public TestFixture TestFixture {
      get { return this.testFixture; }
    }

    public void Reset() {
      this.Duration = TimeSpan.Zero;
      this.Status = TestStatus.NotStarted;
      this.Messages = new string[0];
    }

    public void SetStatus(TestStatus status, string[] infos, string stackTrace, TimeSpan duration) {
      if (this.TestFixture.UnitTest.TUnitProject.TestStart != null) this.TestFixture.UnitTest.TUnitProject.TestStart(this, new TestEventArgs(this));
      this.Status = status;
      Messages = infos;

      this.StackTrace = stackTrace;
      this.Duration = duration;

      this.TestFixture.Duration += this.Duration;
      this.TestFixture.UnitTest.Duration += this.Duration;
      this.TestFixture.UnitTest.TUnitProject.Duration += this.Duration;

      if (this.TestFixture.Status < this.Status) this.TestFixture.Status = this.Status;
      if (this.TestFixture.UnitTest.Status < this.Status) this.TestFixture.UnitTest.Status = this.Status;
      if (this.TestFixture.UnitTest.TUnitProject.Status < this.Status) this.TestFixture.UnitTest.TUnitProject.Status = this.Status;

      if (this.TestFixture.UnitTest.TUnitProject.TestEnd != null) this.TestFixture.UnitTest.TUnitProject.TestEnd(this, new TestEventArgs(this));
    }

    public override string ToString() { return this.Name; }

    private TestFixture testFixture;
  }
}
