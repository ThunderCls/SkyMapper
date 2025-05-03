namespace SkyMapper.UI;

partial class FrmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        dlgInputFolder = new System.Windows.Forms.FolderBrowserDialog();
        statusStrip1 = new System.Windows.Forms.StatusStrip();
        stripStatus = new System.Windows.Forms.ToolStripStatusLabel();
        stripFailedStatus = new System.Windows.Forms.ToolStripStatusLabel();
        stripTimer = new System.Windows.Forms.ToolStripStatusLabel();
        dlgOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
        tabControl1 = new System.Windows.Forms.TabControl();
        tabProcessing = new System.Windows.Forms.TabPage();
        progressLoading = new System.Windows.Forms.ProgressBar();
        btnStop = new System.Windows.Forms.Button();
        btnStart = new System.Windows.Forms.Button();
        listProcessing = new System.Windows.Forms.ListView();
        columnHeader1 = new System.Windows.Forms.ColumnHeader();
        columnHeader2 = new System.Windows.Forms.ColumnHeader();
        columnHeader9 = new System.Windows.Forms.ColumnHeader();
        columnHeader10 = new System.Windows.Forms.ColumnHeader();
        ctxProcessing = new System.Windows.Forms.ContextMenuStrip(components);
        openNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        openHeightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
        excludeFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        excludeFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
        copyFilePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        filePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        tabSettings = new System.Windows.Forms.TabPage();
        checkReprocessFailed = new System.Windows.Forms.CheckBox();
        groupBox2 = new System.Windows.Forms.GroupBox();
        trackHeightIntensity = new System.Windows.Forms.TrackBar();
        trackHeightSteps = new System.Windows.Forms.TrackBar();
        label2 = new System.Windows.Forms.Label();
        txtHeightSteps = new System.Windows.Forms.TextBox();
        txtHeightIntensity = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        trackHeightNumPasses = new System.Windows.Forms.TrackBar();
        txtHeightPasses = new System.Windows.Forms.TextBox();
        groupBox1 = new System.Windows.Forms.GroupBox();
        radioSyncOutputFolder = new System.Windows.Forms.RadioButton();
        radioRemoveOutputFolder = new System.Windows.Forms.RadioButton();
        btnClearCache = new System.Windows.Forms.Button();
        btnReset = new System.Windows.Forms.Button();
        numThreadsCount = new System.Windows.Forms.NumericUpDown();
        label1 = new System.Windows.Forms.Label();
        txtGameLocation = new System.Windows.Forms.TextBox();
        pageExclusions = new System.Windows.Forms.TabPage();
        txtExcludedFolder = new System.Windows.Forms.TextBox();
        listExclusions = new System.Windows.Forms.ListView();
        columnHeader8 = new System.Windows.Forms.ColumnHeader();
        ctxExclusions = new System.Windows.Forms.ContextMenuStrip(components);
        copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
        deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        pageModExclusions = new System.Windows.Forms.TabPage();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        lstModList = new System.Windows.Forms.ListView();
        columnHeader5 = new System.Windows.Forms.ColumnHeader();
        columnHeader3 = new System.Windows.Forms.ColumnHeader();
        columnHeader4 = new System.Windows.Forms.ColumnHeader();
        ctxModList = new System.Windows.Forms.ContextMenuStrip(components);
        excludeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        includeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        excludeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        includeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        txtModsLocation = new System.Windows.Forms.TextBox();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        listView1 = new System.Windows.Forms.ListView();
        columnHeader6 = new System.Windows.Forms.ColumnHeader();
        ctxExcludedMods = new System.Windows.Forms.ContextMenuStrip(components);
        toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        listView2 = new System.Windows.Forms.ListView();
        columnHeader7 = new System.Windows.Forms.ColumnHeader();
        ctxIncludedMods = new System.Windows.Forms.ContextMenuStrip(components);
        toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
        timerProcess = new System.Windows.Forms.Timer(components);
        toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
        toolTipHeightNumPasses = new System.Windows.Forms.ToolTip(components);
        toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
        statusStrip1.SuspendLayout();
        tabControl1.SuspendLayout();
        tabProcessing.SuspendLayout();
        ctxProcessing.SuspendLayout();
        tabSettings.SuspendLayout();
        groupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackHeightIntensity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackHeightSteps).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackHeightNumPasses).BeginInit();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numThreadsCount).BeginInit();
        pageExclusions.SuspendLayout();
        ctxExclusions.SuspendLayout();
        pageModExclusions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ctxModList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        ctxExcludedMods.SuspendLayout();
        ctxIncludedMods.SuspendLayout();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
        statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stripStatus, stripFailedStatus, stripTimer });
        statusStrip1.Location = new System.Drawing.Point(0, 783);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
        statusStrip1.Size = new System.Drawing.Size(1234, 22);
        statusStrip1.TabIndex = 6;
        // 
        // stripStatus
        // 
        stripStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
        stripStatus.Name = "stripStatus";
        stripStatus.Size = new System.Drawing.Size(0, 17);
        // 
        // stripFailedStatus
        // 
        stripFailedStatus.Margin = new System.Windows.Forms.Padding(0, 4, 10, 2);
        stripFailedStatus.Name = "stripFailedStatus";
        stripFailedStatus.Size = new System.Drawing.Size(0, 16);
        // 
        // stripTimer
        // 
        stripTimer.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
        stripTimer.Name = "stripTimer";
        stripTimer.Size = new System.Drawing.Size(0, 17);
        stripTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabProcessing);
        tabControl1.Controls.Add(tabSettings);
        tabControl1.Controls.Add(pageExclusions);
        tabControl1.Controls.Add(pageModExclusions);
        tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl1.Location = new System.Drawing.Point(0, 0);
        tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(1234, 783);
        tabControl1.TabIndex = 0;
        // 
        // tabProcessing
        // 
        tabProcessing.Controls.Add(progressLoading);
        tabProcessing.Controls.Add(btnStop);
        tabProcessing.Controls.Add(btnStart);
        tabProcessing.Controls.Add(listProcessing);
        tabProcessing.Location = new System.Drawing.Point(4, 24);
        tabProcessing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabProcessing.Name = "tabProcessing";
        tabProcessing.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabProcessing.Size = new System.Drawing.Size(1226, 755);
        tabProcessing.TabIndex = 0;
        tabProcessing.Text = "Processing";
        tabProcessing.UseVisualStyleBackColor = true;
        // 
        // progressLoading
        // 
        progressLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
        progressLoading.Location = new System.Drawing.Point(329, 332);
        progressLoading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        progressLoading.MarqueeAnimationSpeed = 20;
        progressLoading.Name = "progressLoading";
        progressLoading.Size = new System.Drawing.Size(553, 18);
        progressLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        progressLoading.TabIndex = 14;
        progressLoading.Value = 25;
        progressLoading.Visible = false;
        // 
        // btnStop
        // 
        btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnStop.Enabled = false;
        btnStop.Location = new System.Drawing.Point(988, 716);
        btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(115, 38);
        btnStop.TabIndex = 13;
        btnStop.Text = "Stop";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // btnStart
        // 
        btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnStart.Location = new System.Drawing.Point(1106, 716);
        btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnStart.Name = "btnStart";
        btnStart.Size = new System.Drawing.Size(115, 38);
        btnStart.TabIndex = 12;
        btnStart.Text = "Start";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // listProcessing
        // 
        listProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        listProcessing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader9, columnHeader10 });
        listProcessing.ContextMenuStrip = ctxProcessing;
        listProcessing.FullRowSelect = true;
        listProcessing.GridLines = true;
        listProcessing.Location = new System.Drawing.Point(6, 3);
        listProcessing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listProcessing.Name = "listProcessing";
        listProcessing.Size = new System.Drawing.Size(1216, 709);
        listProcessing.TabIndex = 11;
        listProcessing.UseCompatibleStateImageBehavior = false;
        listProcessing.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Name = "columnHeader1";
        columnHeader1.Text = "File";
        columnHeader1.Width = 700;
        // 
        // columnHeader2
        // 
        columnHeader2.Name = "columnHeader2";
        columnHeader2.Text = "Status";
        columnHeader2.Width = 150;
        // 
        // columnHeader9
        // 
        columnHeader9.Name = "columnHeader9";
        columnHeader9.Text = "Hash";
        columnHeader9.Width = 200;
        // 
        // columnHeader10
        // 
        columnHeader10.Name = "columnHeader10";
        columnHeader10.Text = "Processed";
        columnHeader10.Width = 100;
        // 
        // ctxProcessing
        // 
        ctxProcessing.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxProcessing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openNormalMenuItem, openHeightMenuItem, toolStripMenuItem12, excludeFolderMenuItem, excludeFilesMenuItem, toolStripMenuItem16, copyFilePathMenuItem });
        ctxProcessing.Name = "ctxProcessing";
        ctxProcessing.Size = new System.Drawing.Size(203, 126);
        ctxProcessing.Text = "Copy File Path";
        ctxProcessing.Opened += ctxProcessing_Opened;
        // 
        // openNormalMenuItem
        // 
        openNormalMenuItem.Name = "openNormalMenuItem";
        openNormalMenuItem.Size = new System.Drawing.Size(202, 22);
        openNormalMenuItem.Text = "Open Normal Map";
        openNormalMenuItem.Click += openFileToolStripMenuItem_Click;
        // 
        // openHeightMenuItem
        // 
        openHeightMenuItem.Name = "openHeightMenuItem";
        openHeightMenuItem.Size = new System.Drawing.Size(202, 22);
        openHeightMenuItem.Text = "Open Destination Folder";
        openHeightMenuItem.Click += openDestinationFolderToolStripMenuItem_Click;
        // 
        // toolStripMenuItem12
        // 
        toolStripMenuItem12.Name = "toolStripMenuItem12";
        toolStripMenuItem12.Size = new System.Drawing.Size(199, 6);
        // 
        // excludeFolderMenuItem
        // 
        excludeFolderMenuItem.Name = "excludeFolderMenuItem";
        excludeFolderMenuItem.Size = new System.Drawing.Size(202, 22);
        excludeFolderMenuItem.Text = "Exclude Folder(s)";
        excludeFolderMenuItem.Click += excludeFolderToolStripMenuItem_Click;
        // 
        // excludeFilesMenuItem
        // 
        excludeFilesMenuItem.Name = "excludeFilesMenuItem";
        excludeFilesMenuItem.Size = new System.Drawing.Size(202, 22);
        excludeFilesMenuItem.Text = "Exclude File(s)";
        excludeFilesMenuItem.Click += excludeFilesMenuItem_Click;
        // 
        // toolStripMenuItem16
        // 
        toolStripMenuItem16.Name = "toolStripMenuItem16";
        toolStripMenuItem16.Size = new System.Drawing.Size(199, 6);
        // 
        // copyFilePathMenuItem
        // 
        copyFilePathMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { filePathToolStripMenuItem, statusToolStripMenuItem, hashToolStripMenuItem, lineToolStripMenuItem });
        copyFilePathMenuItem.Name = "copyFilePathMenuItem";
        copyFilePathMenuItem.Size = new System.Drawing.Size(202, 22);
        copyFilePathMenuItem.Text = "Copy";
        // 
        // filePathToolStripMenuItem
        // 
        filePathToolStripMenuItem.Name = "filePathToolStripMenuItem";
        filePathToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        filePathToolStripMenuItem.Text = "File Path";
        filePathToolStripMenuItem.Click += filePathToolStripMenuItem_Click;
        // 
        // statusToolStripMenuItem
        // 
        statusToolStripMenuItem.Name = "statusToolStripMenuItem";
        statusToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        statusToolStripMenuItem.Text = "Status";
        statusToolStripMenuItem.Click += statusToolStripMenuItem_Click;
        // 
        // hashToolStripMenuItem
        // 
        hashToolStripMenuItem.Name = "hashToolStripMenuItem";
        hashToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        hashToolStripMenuItem.Text = "Hash";
        hashToolStripMenuItem.Click += hashToolStripMenuItem_Click;
        // 
        // lineToolStripMenuItem
        // 
        lineToolStripMenuItem.Name = "lineToolStripMenuItem";
        lineToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        lineToolStripMenuItem.Text = "Line";
        lineToolStripMenuItem.Click += lineToolStripMenuItem_Click;
        // 
        // tabSettings
        // 
        tabSettings.Controls.Add(checkReprocessFailed);
        tabSettings.Controls.Add(groupBox2);
        tabSettings.Controls.Add(groupBox1);
        tabSettings.Controls.Add(btnClearCache);
        tabSettings.Controls.Add(btnReset);
        tabSettings.Controls.Add(numThreadsCount);
        tabSettings.Controls.Add(label1);
        tabSettings.Controls.Add(txtGameLocation);
        tabSettings.Location = new System.Drawing.Point(4, 24);
        tabSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabSettings.Name = "tabSettings";
        tabSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabSettings.Size = new System.Drawing.Size(1226, 755);
        tabSettings.TabIndex = 1;
        tabSettings.Text = "Settings";
        tabSettings.UseVisualStyleBackColor = true;
        // 
        // checkReprocessFailed
        // 
        checkReprocessFailed.AutoSize = true;
        checkReprocessFailed.Location = new System.Drawing.Point(164, 39);
        checkReprocessFailed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        checkReprocessFailed.Name = "checkReprocessFailed";
        checkReprocessFailed.Size = new System.Drawing.Size(135, 19);
        checkReprocessFailed.TabIndex = 31;
        checkReprocessFailed.Text = "Reprocess failed files";
        checkReprocessFailed.UseVisualStyleBackColor = true;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(trackHeightIntensity);
        groupBox2.Controls.Add(trackHeightSteps);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(txtHeightSteps);
        groupBox2.Controls.Add(txtHeightIntensity);
        groupBox2.Controls.Add(label4);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(trackHeightNumPasses);
        groupBox2.Controls.Add(txtHeightPasses);
        groupBox2.Location = new System.Drawing.Point(7, 65);
        groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        groupBox2.Size = new System.Drawing.Size(497, 143);
        groupBox2.TabIndex = 30;
        groupBox2.TabStop = false;
        groupBox2.Text = "Parallax Settings";
        // 
        // trackHeightIntensity
        // 
        trackHeightIntensity.AutoSize = false;
        trackHeightIntensity.Location = new System.Drawing.Point(238, 38);
        trackHeightIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        trackHeightIntensity.Maximum = 50;
        trackHeightIntensity.Minimum = -50;
        trackHeightIntensity.Name = "trackHeightIntensity";
        trackHeightIntensity.Size = new System.Drawing.Size(190, 17);
        trackHeightIntensity.TabIndex = 16;
        toolTipHeightNumPasses.SetToolTip(trackHeightIntensity, "Final intensity (contrast balance) of the height map (recommended -20)");
        trackHeightIntensity.Value = -20;
        trackHeightIntensity.ValueChanged += trackHeightIntensity_ValueChanged;
        // 
        // trackHeightSteps
        // 
        trackHeightSteps.AutoSize = false;
        trackHeightSteps.Location = new System.Drawing.Point(238, 94);
        trackHeightSteps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        trackHeightSteps.Maximum = 75;
        trackHeightSteps.Minimum = 1;
        trackHeightSteps.Name = "trackHeightSteps";
        trackHeightSteps.Size = new System.Drawing.Size(190, 17);
        trackHeightSteps.TabIndex = 29;
        toolTipHeightNumPasses.SetToolTip(trackHeightSteps, "Maximum displacement between two adjacent pixels (recommended 1)");
        trackHeightSteps.Value = 1;
        trackHeightSteps.ValueChanged += trackHeightSteps_ValueChanged;
        // 
        // label2
        // 
        label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(61, 40);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(121, 15);
        label2.TabIndex = 15;
        label2.Text = "Height Map Intensity:";
        toolTipHeightNumPasses.SetToolTip(label2, "Final intensity (contrast balance) of the height map (recommended -20)");
        // 
        // txtHeightSteps
        // 
        txtHeightSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtHeightSteps.Location = new System.Drawing.Point(188, 94);
        txtHeightSteps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtHeightSteps.Name = "txtHeightSteps";
        txtHeightSteps.Size = new System.Drawing.Size(45, 23);
        txtHeightSteps.TabIndex = 28;
        toolTipHeightNumPasses.SetToolTip(txtHeightSteps, "Maximum displacement between two adjacent pixels (recommended 1)");
        txtHeightSteps.KeyPress += txtHeightSteps_KeyPress;
        txtHeightSteps.Leave += txtHeightSteps_Leave;
        // 
        // txtHeightIntensity
        // 
        txtHeightIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left));
        txtHeightIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtHeightIntensity.Location = new System.Drawing.Point(188, 38);
        txtHeightIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtHeightIntensity.Name = "txtHeightIntensity";
        txtHeightIntensity.Size = new System.Drawing.Size(45, 23);
        txtHeightIntensity.TabIndex = 17;
        toolTipHeightNumPasses.SetToolTip(txtHeightIntensity, "Final intensity (contrast balance) of the height map (recommended -20)");
        txtHeightIntensity.KeyPress += txtHeightIntensity_KeyPress;
        txtHeightIntensity.Leave += txtHeightIntensity_Leave;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(61, 97);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(103, 17);
        label4.TabIndex = 27;
        label4.Text = "Max Step Height:";
        toolTipHeightNumPasses.SetToolTip(label4, "Maximum displacement between two adjacent pixels (recommended 1)");
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(61, 69);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(121, 17);
        label3.TabIndex = 24;
        label3.Text = "Height Map Passes:";
        toolTipHeightNumPasses.SetToolTip(label3, ("Number of passes to perform, more passes produces a more accurate result, but tak" + "es longer (recommended 128)"));
        // 
        // trackHeightNumPasses
        // 
        trackHeightNumPasses.AutoSize = false;
        trackHeightNumPasses.Location = new System.Drawing.Point(238, 66);
        trackHeightNumPasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        trackHeightNumPasses.Maximum = 4096;
        trackHeightNumPasses.Minimum = 32;
        trackHeightNumPasses.Name = "trackHeightNumPasses";
        trackHeightNumPasses.Size = new System.Drawing.Size(190, 17);
        trackHeightNumPasses.TabIndex = 26;
        toolTipHeightNumPasses.SetToolTip(trackHeightNumPasses, ("Number of passes to perform, more passes produces a more accurate result, but tak" + "es longer (recommended 128)"));
        trackHeightNumPasses.Value = 128;
        trackHeightNumPasses.ValueChanged += trackHeightNumPasses_ValueChanged;
        // 
        // txtHeightPasses
        // 
        txtHeightPasses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtHeightPasses.Location = new System.Drawing.Point(188, 66);
        txtHeightPasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtHeightPasses.Name = "txtHeightPasses";
        txtHeightPasses.Size = new System.Drawing.Size(45, 23);
        txtHeightPasses.TabIndex = 25;
        toolTipHeightNumPasses.SetToolTip(txtHeightPasses, ("Number of passes to perform, more passes produces a more accurate result, but tak" + "es longer (recommended 128)"));
        txtHeightPasses.KeyPress += txtHeightPasses_KeyPress;
        txtHeightPasses.Leave += txtHeightPasses_Leave;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(radioSyncOutputFolder);
        groupBox1.Controls.Add(radioRemoveOutputFolder);
        groupBox1.Location = new System.Drawing.Point(7, 213);
        groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        groupBox1.Size = new System.Drawing.Size(497, 100);
        groupBox1.TabIndex = 23;
        groupBox1.TabStop = false;
        groupBox1.Text = "Output";
        // 
        // radioSyncOutputFolder
        // 
        radioSyncOutputFolder.Checked = true;
        radioSyncOutputFolder.Location = new System.Drawing.Point(61, 54);
        radioSyncOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        radioSyncOutputFolder.Name = "radioSyncOutputFolder";
        radioSyncOutputFolder.Size = new System.Drawing.Size(186, 18);
        radioSyncOutputFolder.TabIndex = 1;
        radioSyncOutputFolder.TabStop = true;
        radioSyncOutputFolder.Text = "Keep output folder in sync";
        radioSyncOutputFolder.UseVisualStyleBackColor = true;
        // 
        // radioRemoveOutputFolder
        // 
        radioRemoveOutputFolder.Location = new System.Drawing.Point(61, 32);
        radioRemoveOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        radioRemoveOutputFolder.Name = "radioRemoveOutputFolder";
        radioRemoveOutputFolder.Size = new System.Drawing.Size(201, 18);
        radioRemoveOutputFolder.TabIndex = 0;
        radioRemoveOutputFolder.Text = "Remove output folder when finished";
        radioRemoveOutputFolder.UseVisualStyleBackColor = true;
        // 
        // btnClearCache
        // 
        btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnClearCache.Location = new System.Drawing.Point(988, 717);
        btnClearCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnClearCache.Name = "btnClearCache";
        btnClearCache.Size = new System.Drawing.Size(115, 38);
        btnClearCache.TabIndex = 22;
        btnClearCache.Text = "Clear Cache";
        btnClearCache.UseVisualStyleBackColor = true;
        btnClearCache.Click += btnClearCache_Click;
        // 
        // btnReset
        // 
        btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnReset.Location = new System.Drawing.Point(1109, 717);
        btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnReset.Name = "btnReset";
        btnReset.Size = new System.Drawing.Size(115, 38);
        btnReset.TabIndex = 19;
        btnReset.Text = "Reset Values";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // numThreadsCount
        // 
        numThreadsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        numThreadsCount.Location = new System.Drawing.Point(90, 37);
        numThreadsCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        numThreadsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numThreadsCount.Name = "numThreadsCount";
        numThreadsCount.Size = new System.Drawing.Size(58, 23);
        numThreadsCount.TabIndex = 14;
        toolTipHeightNumPasses.SetToolTip(numThreadsCount, "Threads to run in parallel (no more than 10 recommended)");
        numThreadsCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
        numThreadsCount.KeyPress += numThreadsCount_KeyPress;
        // 
        // label1
        // 
        label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(7, 40);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(77, 15);
        label1.TabIndex = 13;
        label1.Text = "Max Threads:";
        // 
        // txtGameLocation
        // 
        txtGameLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtGameLocation.Location = new System.Drawing.Point(7, 10);
        txtGameLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtGameLocation.Name = "txtGameLocation";
        txtGameLocation.Size = new System.Drawing.Size(497, 23);
        txtGameLocation.TabIndex = 12;
        txtGameLocation.Text = "Game data location...";
        txtGameLocation.Click += txtGameLocation_Click;
        txtGameLocation.KeyPress += txtGameLocation_KeyPress;
        // 
        // pageExclusions
        // 
        pageExclusions.Controls.Add(txtExcludedFolder);
        pageExclusions.Controls.Add(listExclusions);
        pageExclusions.Location = new System.Drawing.Point(4, 24);
        pageExclusions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageExclusions.Name = "pageExclusions";
        pageExclusions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageExclusions.Size = new System.Drawing.Size(1226, 755);
        pageExclusions.TabIndex = 3;
        pageExclusions.Text = "Exclusions";
        pageExclusions.UseVisualStyleBackColor = true;
        // 
        // txtExcludedFolder
        // 
        txtExcludedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtExcludedFolder.Dock = System.Windows.Forms.DockStyle.Top;
        txtExcludedFolder.Location = new System.Drawing.Point(3, 2);
        txtExcludedFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtExcludedFolder.Name = "txtExcludedFolder";
        txtExcludedFolder.Size = new System.Drawing.Size(1220, 23);
        txtExcludedFolder.TabIndex = 30;
        txtExcludedFolder.KeyPress += txtExcludedFolder_KeyPress;
        // 
        // listExclusions
        // 
        listExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        listExclusions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        listExclusions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader8 });
        listExclusions.ContextMenuStrip = ctxExclusions;
        listExclusions.FullRowSelect = true;
        listExclusions.GridLines = true;
        listExclusions.Location = new System.Drawing.Point(3, 29);
        listExclusions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listExclusions.Name = "listExclusions";
        listExclusions.Scrollable = false;
        listExclusions.Size = new System.Drawing.Size(1222, 730);
        listExclusions.TabIndex = 29;
        listExclusions.UseCompatibleStateImageBehavior = false;
        listExclusions.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader8
        // 
        columnHeader8.Name = "columnHeader8";
        columnHeader8.Text = "Exclusions";
        columnHeader8.Width = 900;
        // 
        // ctxExclusions
        // 
        ctxExclusions.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxExclusions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyToolStripMenuItem, toolStripMenuItem19, deleteToolStripMenuItem });
        ctxExclusions.Name = "ctxExcludedFolders";
        ctxExclusions.Size = new System.Drawing.Size(108, 54);
        ctxExclusions.Opening += ctxExcludedFolders_Opening;
        // 
        // copyToolStripMenuItem
        // 
        copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        copyToolStripMenuItem.Text = "Copy";
        copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
        // 
        // toolStripMenuItem19
        // 
        toolStripMenuItem19.Name = "toolStripMenuItem19";
        toolStripMenuItem19.Size = new System.Drawing.Size(104, 6);
        // 
        // deleteToolStripMenuItem
        // 
        deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
        deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        deleteToolStripMenuItem.Text = "Delete";
        deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
        // 
        // pageModExclusions
        // 
        pageModExclusions.Controls.Add(splitContainer1);
        pageModExclusions.Location = new System.Drawing.Point(4, 24);
        pageModExclusions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageModExclusions.Name = "pageModExclusions";
        pageModExclusions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageModExclusions.Size = new System.Drawing.Size(1226, 755);
        pageModExclusions.TabIndex = 2;
        pageModExclusions.Text = "Mod Exclusions";
        pageModExclusions.UseVisualStyleBackColor = true;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(3, 2);
        splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(lstModList);
        splitContainer1.Panel1.Controls.Add(txtModsLocation);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Size = new System.Drawing.Size(1220, 751);
        splitContainer1.SplitterDistance = 675;
        splitContainer1.TabIndex = 29;
        // 
        // lstModList
        // 
        lstModList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lstModList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader5, columnHeader3, columnHeader4 });
        lstModList.ContextMenuStrip = ctxModList;
        lstModList.Dock = System.Windows.Forms.DockStyle.Fill;
        lstModList.FullRowSelect = true;
        lstModList.GridLines = true;
        lstModList.Location = new System.Drawing.Point(0, 23);
        lstModList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        lstModList.Name = "lstModList";
        lstModList.Scrollable = false;
        lstModList.Size = new System.Drawing.Size(675, 728);
        lstModList.TabIndex = 24;
        lstModList.UseCompatibleStateImageBehavior = false;
        lstModList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader5
        // 
        columnHeader5.Name = "columnHeader5";
        columnHeader5.Text = "Mod";
        columnHeader5.Width = 400;
        // 
        // columnHeader3
        // 
        columnHeader3.Name = "columnHeader3";
        columnHeader3.Text = "Excluded";
        // 
        // columnHeader4
        // 
        columnHeader4.Name = "columnHeader4";
        columnHeader4.Text = "Included";
        // 
        // ctxModList
        // 
        ctxModList.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxModList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { excludeToolStripMenuItem, includeToolStripMenuItem, toolStripMenuItem1, excludeToolStripMenuItem1, includeToolStripMenuItem1 });
        ctxModList.Name = "ctxModList";
        ctxModList.Size = new System.Drawing.Size(138, 98);
        // 
        // excludeToolStripMenuItem
        // 
        excludeToolStripMenuItem.Name = "excludeToolStripMenuItem";
        excludeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        excludeToolStripMenuItem.Text = "Select All";
        // 
        // includeToolStripMenuItem
        // 
        includeToolStripMenuItem.Name = "includeToolStripMenuItem";
        includeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        includeToolStripMenuItem.Text = "Select None";
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
        // 
        // excludeToolStripMenuItem1
        // 
        excludeToolStripMenuItem1.Name = "excludeToolStripMenuItem1";
        excludeToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
        excludeToolStripMenuItem1.Text = "Exclude";
        // 
        // includeToolStripMenuItem1
        // 
        includeToolStripMenuItem1.Name = "includeToolStripMenuItem1";
        includeToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
        includeToolStripMenuItem1.Text = "Include";
        // 
        // txtModsLocation
        // 
        txtModsLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtModsLocation.Dock = System.Windows.Forms.DockStyle.Top;
        txtModsLocation.Location = new System.Drawing.Point(0, 0);
        txtModsLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtModsLocation.Name = "txtModsLocation";
        txtModsLocation.Size = new System.Drawing.Size(675, 23);
        txtModsLocation.TabIndex = 23;
        txtModsLocation.Text = "Mods location...";
        txtModsLocation.Click += txtModsLocation_Click;
        txtModsLocation.KeyPress += txtModsLocation_KeyPress;
        // 
        // splitContainer2
        // 
        splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer2.Location = new System.Drawing.Point(0, 0);
        splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        splitContainer2.Name = "splitContainer2";
        splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.Controls.Add(listView1);
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.Controls.Add(listView2);
        splitContainer2.Size = new System.Drawing.Size(541, 751);
        splitContainer2.SplitterDistance = 339;
        splitContainer2.SplitterWidth = 2;
        splitContainer2.TabIndex = 0;
        // 
        // listView1
        // 
        listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader6 });
        listView1.ContextMenuStrip = ctxExcludedMods;
        listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        listView1.FullRowSelect = true;
        listView1.GridLines = true;
        listView1.Location = new System.Drawing.Point(0, 0);
        listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listView1.Name = "listView1";
        listView1.Scrollable = false;
        listView1.Size = new System.Drawing.Size(541, 339);
        listView1.TabIndex = 28;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader6
        // 
        columnHeader6.Name = "columnHeader6";
        columnHeader6.Text = "Excluded Mod";
        columnHeader6.Width = 400;
        // 
        // ctxExcludedMods
        // 
        ctxExcludedMods.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxExcludedMods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator1, toolStripMenuItem4 });
        ctxExcludedMods.Name = "ctxModList";
        ctxExcludedMods.Size = new System.Drawing.Size(138, 76);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem2.Text = "Select All";
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem3.Text = "Select None";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem4.Text = "Remove";
        // 
        // listView2
        // 
        listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader7 });
        listView2.ContextMenuStrip = ctxIncludedMods;
        listView2.Dock = System.Windows.Forms.DockStyle.Fill;
        listView2.FullRowSelect = true;
        listView2.GridLines = true;
        listView2.Location = new System.Drawing.Point(0, 0);
        listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listView2.Name = "listView2";
        listView2.Scrollable = false;
        listView2.Size = new System.Drawing.Size(541, 410);
        listView2.TabIndex = 29;
        listView2.UseCompatibleStateImageBehavior = false;
        listView2.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader7
        // 
        columnHeader7.Name = "columnHeader7";
        columnHeader7.Text = "Included Mods";
        columnHeader7.Width = 400;
        // 
        // ctxIncludedMods
        // 
        ctxIncludedMods.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxIncludedMods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem6, toolStripSeparator2, toolStripMenuItem7 });
        ctxIncludedMods.Name = "ctxModList";
        ctxIncludedMods.Size = new System.Drawing.Size(138, 76);
        // 
        // toolStripMenuItem5
        // 
        toolStripMenuItem5.Name = "toolStripMenuItem5";
        toolStripMenuItem5.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem5.Text = "Select All";
        // 
        // toolStripMenuItem6
        // 
        toolStripMenuItem6.Name = "toolStripMenuItem6";
        toolStripMenuItem6.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem6.Text = "Select None";
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
        // 
        // toolStripMenuItem7
        // 
        toolStripMenuItem7.Name = "toolStripMenuItem7";
        toolStripMenuItem7.Size = new System.Drawing.Size(137, 22);
        toolStripMenuItem7.Text = "Remove";
        // 
        // toolStripMenuItem8
        // 
        toolStripMenuItem8.Name = "toolStripMenuItem8";
        toolStripMenuItem8.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem9
        // 
        toolStripMenuItem9.Name = "toolStripMenuItem9";
        toolStripMenuItem9.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem10
        // 
        toolStripMenuItem10.Name = "toolStripMenuItem10";
        toolStripMenuItem10.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem11
        // 
        toolStripMenuItem11.Name = "toolStripMenuItem11";
        toolStripMenuItem11.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem13
        // 
        toolStripMenuItem13.Name = "toolStripMenuItem13";
        toolStripMenuItem13.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
        // 
        // toolStripMenuItem14
        // 
        toolStripMenuItem14.Name = "toolStripMenuItem14";
        toolStripMenuItem14.Size = new System.Drawing.Size(32, 19);
        // 
        // timerProcess
        // 
        timerProcess.Interval = 1000;
        timerProcess.Tick += timerProcess_Tick;
        // 
        // toolStripMenuItem15
        // 
        toolStripMenuItem15.Name = "toolStripMenuItem15";
        toolStripMenuItem15.Size = new System.Drawing.Size(32, 19);
        // 
        // toolTipHeightNumPasses
        // 
        toolTipHeightNumPasses.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        toolTipHeightNumPasses.ToolTipTitle = "Info";
        // 
        // toolStripMenuItem17
        // 
        toolStripMenuItem17.Name = "toolStripMenuItem17";
        toolStripMenuItem17.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem18
        // 
        toolStripMenuItem18.Name = "toolStripMenuItem18";
        toolStripMenuItem18.Size = new System.Drawing.Size(32, 19);
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1234, 805);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip1);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "SkyMapper v1.1";
        FormClosing += FrmMain_FormClosing;
        Load += FrmMain_LoadAsync;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabProcessing.ResumeLayout(false);
        ctxProcessing.ResumeLayout(false);
        tabSettings.ResumeLayout(false);
        tabSettings.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackHeightIntensity).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackHeightSteps).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackHeightNumPasses).EndInit();
        groupBox1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numThreadsCount).EndInit();
        pageExclusions.ResumeLayout(false);
        pageExclusions.PerformLayout();
        ctxExclusions.ResumeLayout(false);
        pageModExclusions.ResumeLayout(false);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ctxModList.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        ctxExcludedMods.ResumeLayout(false);
        ctxIncludedMods.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtHeightPasses;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TrackBar trackHeightNumPasses;

    private System.Windows.Forms.TrackBar trackHeightSteps;

    private System.Windows.Forms.TextBox txtHeightSteps;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.RadioButton radioRemoveOutputFolder;
    private System.Windows.Forms.RadioButton radioSyncOutputFolder;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.Button btnClearCache;

    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;

    private System.Windows.Forms.ProgressBar progressLoading;

    private System.Windows.Forms.ColumnHeader columnHeader9;
    private System.Windows.Forms.ColumnHeader columnHeader10;

    #endregion

    private FolderBrowserDialog dlgInputFolder;
    private StatusStrip statusStrip1;
    private FolderBrowserDialog dlgOutputFolder;
    private ToolStripStatusLabel stripStatus;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabProcessing;
    private System.Windows.Forms.TabPage tabSettings;
    private System.Windows.Forms.ListView listProcessing;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.TextBox txtHeightIntensity;
    private System.Windows.Forms.TrackBar trackHeightIntensity;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numThreadsCount;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtGameLocation;
    private TabPage pageModExclusions;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ListView lstModList;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private System.Windows.Forms.TextBox txtModsLocation;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.ListView listView1;
    private ColumnHeader columnHeader6;
    private System.Windows.Forms.ListView listView2;
    private ColumnHeader columnHeader7;
    private ContextMenuStrip ctxModList;
    private ToolStripMenuItem excludeToolStripMenuItem;
    private ToolStripMenuItem includeToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem excludeToolStripMenuItem1;
    private ToolStripMenuItem includeToolStripMenuItem1;
    private ContextMenuStrip ctxExcludedMods;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem toolStripMenuItem3;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem toolStripMenuItem4;
    private ContextMenuStrip ctxIncludedMods;
    private ToolStripMenuItem toolStripMenuItem5;
    private ToolStripMenuItem toolStripMenuItem6;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem toolStripMenuItem7;
    private System.Windows.Forms.ContextMenuStrip ctxProcessing;
    private System.Windows.Forms.ToolStripMenuItem openNormalMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openHeightMenuItem;
    private TabPage pageExclusions;
    private System.Windows.Forms.ListView listExclusions;
    private System.Windows.Forms.ColumnHeader columnHeader8;
    private System.Windows.Forms.TextBox txtExcludedFolder;
    private System.Windows.Forms.ContextMenuStrip ctxExclusions;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.Button btnReset;
    private ToolStripSeparator toolStripMenuItem12;
    private ToolStripMenuItem copyFilePathMenuItem;
    private ToolStripMenuItem excludeFolderMenuItem;
    private ToolStripStatusLabel stripTimer;
    private System.Windows.Forms.Timer timerProcess;
    private ToolStripMenuItem filePathToolStripMenuItem;
    private ToolStripMenuItem statusToolStripMenuItem;
    private ToolStripMenuItem hashToolStripMenuItem;
    private ToolStripMenuItem lineToolStripMenuItem;
    private ToolStripMenuItem excludeFilesMenuItem;
    private ToolStripSeparator toolStripMenuItem16;
    private ToolTip toolTipHeightNumPasses;
    private ToolStripStatusLabel stripFailedStatus;
    private CheckBox checkReprocessFailed;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem19;
}