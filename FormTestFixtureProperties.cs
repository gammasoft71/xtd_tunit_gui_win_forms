﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tunit {
  public partial class FormTestFixtureProperties : Form {
    public FormTestFixtureProperties() {
      InitializeComponent();
    }
    public FormTestFixtureProperties(TestFixture testFixture) {
      InitializeComponent();
      this.Text = $"{testFixture.Name} properties";
      this.labelTestFixtureName.Text = testFixture.Name;
      this.labelTests.Text = testFixture.TestCount.ToString();
      switch (testFixture.Status) {
        case TestStatus.NotStarted:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.NotStartedColor;
          this.labelStatus.Text = "Not Started";
          break;
        case TestStatus.Succeed:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.SucceedColor;
          this.labelStatus.Text = "Succeed";
          break;
        case TestStatus.Ignored:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.IgnoredColor;
          this.labelStatus.Text = "Ignored";
          break;
        case TestStatus.Aborted:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.AbortedColor;
          this.labelStatus.Text = "Aborted";
          break;
        case TestStatus.Failed:
          this.pictureBoxStatus.Image = tunit.Properties.Resources.FailedColor;
          this.labelStatus.Text = "Failed";
          break;
        default:
          break;
      }
      this.richTextBoxFile.Text = testFixture.UnitTest.FileName;
      this.labelTime.Text = testFixture.Duration.ToString();
      this.listBoxTests.Items.AddRange(testFixture.Tests);
    }
  }
}
