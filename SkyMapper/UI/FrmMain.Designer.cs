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
        copyFilePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        filePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        excludeFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        tabSettings = new System.Windows.Forms.TabPage();
        btnClearCache = new System.Windows.Forms.Button();
        checkKeepOutputInSync = new System.Windows.Forms.CheckBox();
        checkRemoveOutput = new System.Windows.Forms.CheckBox();
        btnReset = new System.Windows.Forms.Button();
        btnSaveSettings = new System.Windows.Forms.Button();
        txtHeightIntensity = new System.Windows.Forms.TextBox();
        trackHeightIntensity = new System.Windows.Forms.TrackBar();
        label2 = new System.Windows.Forms.Label();
        numThreadsCount = new System.Windows.Forms.NumericUpDown();
        label1 = new System.Windows.Forms.Label();
        txtGameLocation = new System.Windows.Forms.TextBox();
        pageFolderExclusions = new System.Windows.Forms.TabPage();
        txtExcludedFolder = new System.Windows.Forms.TextBox();
        listExcludedFolders = new System.Windows.Forms.ListView();
        columnHeader8 = new System.Windows.Forms.ColumnHeader();
        ctxExcludedFolders = new System.Windows.Forms.ContextMenuStrip(components);
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
        statusStrip1.SuspendLayout();
        tabControl1.SuspendLayout();
        tabProcessing.SuspendLayout();
        ctxProcessing.SuspendLayout();
        tabSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackHeightIntensity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numThreadsCount).BeginInit();
        pageFolderExclusions.SuspendLayout();
        ctxExcludedFolders.SuspendLayout();
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
        statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stripStatus, stripTimer });
        statusStrip1.Location = new System.Drawing.Point(0, 790);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
        statusStrip1.Size = new System.Drawing.Size(1202, 22);
        statusStrip1.TabIndex = 6;
        // 
        // stripStatus
        // 
        stripStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
        stripStatus.Name = "stripStatus";
        stripStatus.Size = new System.Drawing.Size(0, 17);
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
        tabControl1.Controls.Add(pageFolderExclusions);
        tabControl1.Controls.Add(pageModExclusions);
        tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl1.Location = new System.Drawing.Point(0, 0);
        tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(1202, 790);
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
        tabProcessing.Size = new System.Drawing.Size(1194, 762);
        tabProcessing.TabIndex = 0;
        tabProcessing.Text = "Processing";
        tabProcessing.UseVisualStyleBackColor = true;
        // 
        // progressLoading
        // 
        progressLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
        progressLoading.Location = new System.Drawing.Point(401, 346);
        progressLoading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        progressLoading.MarqueeAnimationSpeed = 20;
        progressLoading.Name = "progressLoading";
        progressLoading.Size = new System.Drawing.Size(441, 21);
        progressLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        progressLoading.TabIndex = 14;
        progressLoading.Value = 25;
        progressLoading.Visible = false;
        // 
        // btnStop
        // 
        btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnStop.Enabled = false;
        btnStop.Location = new System.Drawing.Point(920, 726);
        btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(131, 30);
        btnStop.TabIndex = 13;
        btnStop.Text = "Stop";
        btnStop.UseVisualStyleBackColor = true;
        btnStop.Click += btnStop_Click;
        // 
        // btnStart
        // 
        btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnStart.Location = new System.Drawing.Point(1056, 726);
        btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnStart.Name = "btnStart";
        btnStart.Size = new System.Drawing.Size(131, 30);
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
        listProcessing.Location = new System.Drawing.Point(7, 4);
        listProcessing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listProcessing.Name = "listProcessing";
        listProcessing.Size = new System.Drawing.Size(1182, 715);
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
        ctxProcessing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openNormalMenuItem, openHeightMenuItem, toolStripMenuItem12, copyFilePathMenuItem, excludeFolderMenuItem });
        ctxProcessing.Name = "ctxProcessing";
        ctxProcessing.Size = new System.Drawing.Size(203, 98);
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
        // excludeFolderMenuItem
        // 
        excludeFolderMenuItem.Name = "excludeFolderMenuItem";
        excludeFolderMenuItem.Size = new System.Drawing.Size(202, 22);
        excludeFolderMenuItem.Text = "Exclude Folder(s)";
        excludeFolderMenuItem.Click += excludeFolderToolStripMenuItem_Click;
        // 
        // tabSettings
        // 
        tabSettings.Controls.Add(btnClearCache);
        tabSettings.Controls.Add(checkKeepOutputInSync);
        tabSettings.Controls.Add(checkRemoveOutput);
        tabSettings.Controls.Add(btnReset);
        tabSettings.Controls.Add(btnSaveSettings);
        tabSettings.Controls.Add(txtHeightIntensity);
        tabSettings.Controls.Add(trackHeightIntensity);
        tabSettings.Controls.Add(label2);
        tabSettings.Controls.Add(numThreadsCount);
        tabSettings.Controls.Add(label1);
        tabSettings.Controls.Add(txtGameLocation);
        tabSettings.Location = new System.Drawing.Point(4, 24);
        tabSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabSettings.Name = "tabSettings";
        tabSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        tabSettings.Size = new System.Drawing.Size(1194, 762);
        tabSettings.TabIndex = 1;
        tabSettings.Text = "Settings";
        tabSettings.UseVisualStyleBackColor = true;
        // 
        // btnClearCache
        // 
        btnClearCache.Location = new System.Drawing.Point(783, 729);
        btnClearCache.Name = "btnClearCache";
        btnClearCache.Size = new System.Drawing.Size(131, 30);
        btnClearCache.TabIndex = 22;
        btnClearCache.Text = "Clear Cache";
        btnClearCache.UseVisualStyleBackColor = true;
        btnClearCache.Click += btnClearCache_Click;
        // 
        // checkKeepOutputInSync
        // 
        checkKeepOutputInSync.AutoSize = true;
        checkKeepOutputInSync.Checked = true;
        checkKeepOutputInSync.CheckState = System.Windows.Forms.CheckState.Checked;
        checkKeepOutputInSync.Location = new System.Drawing.Point(8, 102);
        checkKeepOutputInSync.Name = "checkKeepOutputInSync";
        checkKeepOutputInSync.Size = new System.Drawing.Size(165, 19);
        checkKeepOutputInSync.TabIndex = 21;
        checkKeepOutputInSync.Text = "Keep output folder in sync";
        checkKeepOutputInSync.UseVisualStyleBackColor = true;
        // 
        // checkRemoveOutput
        // 
        checkRemoveOutput.AutoSize = true;
        checkRemoveOutput.Location = new System.Drawing.Point(8, 77);
        checkRemoveOutput.Name = "checkRemoveOutput";
        checkRemoveOutput.Size = new System.Drawing.Size(219, 19);
        checkRemoveOutput.TabIndex = 20;
        checkRemoveOutput.Text = "Remove output folder when finished";
        checkRemoveOutput.UseVisualStyleBackColor = true;
        // 
        // btnReset
        // 
        btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnReset.Location = new System.Drawing.Point(920, 729);
        btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnReset.Name = "btnReset";
        btnReset.Size = new System.Drawing.Size(131, 30);
        btnReset.TabIndex = 19;
        btnReset.Text = "Reset Values";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnSaveSettings.Location = new System.Drawing.Point(1056, 729);
        btnSaveSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new System.Drawing.Size(131, 30);
        btnSaveSettings.TabIndex = 18;
        btnSaveSettings.Text = "Save";
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.Click += btnSaveSettings_Click;
        // 
        // txtHeightIntensity
        // 
        txtHeightIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left));
        txtHeightIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtHeightIntensity.Location = new System.Drawing.Point(302, 49);
        txtHeightIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtHeightIntensity.Name = "txtHeightIntensity";
        txtHeightIntensity.Size = new System.Drawing.Size(51, 23);
        txtHeightIntensity.TabIndex = 17;
        txtHeightIntensity.KeyPress += txtHeightIntensity_KeyPress;
        // 
        // trackHeightIntensity
        // 
        trackHeightIntensity.AutoSize = false;
        trackHeightIntensity.Location = new System.Drawing.Point(359, 49);
        trackHeightIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        trackHeightIntensity.Maximum = -50;
        trackHeightIntensity.Minimum = -100;
        trackHeightIntensity.Name = "trackHeightIntensity";
        trackHeightIntensity.Size = new System.Drawing.Size(215, 28);
        trackHeightIntensity.TabIndex = 16;
        trackHeightIntensity.Value = -88;
        trackHeightIntensity.ValueChanged += trackHeightIntensity_ValueChanged;
        // 
        // label2
        // 
        label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(175, 51);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(121, 15);
        label2.TabIndex = 15;
        label2.Text = "Height Map Intensity:";
        // 
        // numThreadsCount
        // 
        numThreadsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        numThreadsCount.Location = new System.Drawing.Point(91, 49);
        numThreadsCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        numThreadsCount.Name = "numThreadsCount";
        numThreadsCount.Size = new System.Drawing.Size(66, 23);
        numThreadsCount.TabIndex = 14;
        numThreadsCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
        numThreadsCount.KeyPress += numThreadsCount_KeyPress;
        // 
        // label1
        // 
        label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(8, 53);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(77, 15);
        label1.TabIndex = 13;
        label1.Text = "Max Threads:";
        // 
        // txtGameLocation
        // 
        txtGameLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtGameLocation.Location = new System.Drawing.Point(8, 13);
        txtGameLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtGameLocation.Name = "txtGameLocation";
        txtGameLocation.Size = new System.Drawing.Size(568, 23);
        txtGameLocation.TabIndex = 12;
        txtGameLocation.Text = "Game data location...";
        txtGameLocation.Click += txtGameLocation_Click;
        txtGameLocation.KeyPress += txtGameLocation_KeyPress;
        // 
        // pageFolderExclusions
        // 
        pageFolderExclusions.Controls.Add(txtExcludedFolder);
        pageFolderExclusions.Controls.Add(listExcludedFolders);
        pageFolderExclusions.Location = new System.Drawing.Point(4, 24);
        pageFolderExclusions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageFolderExclusions.Name = "pageFolderExclusions";
        pageFolderExclusions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
        pageFolderExclusions.Size = new System.Drawing.Size(1194, 762);
        pageFolderExclusions.TabIndex = 3;
        pageFolderExclusions.Text = "Folder Exclusions";
        pageFolderExclusions.UseVisualStyleBackColor = true;
        // 
        // txtExcludedFolder
        // 
        txtExcludedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtExcludedFolder.Dock = System.Windows.Forms.DockStyle.Top;
        txtExcludedFolder.Location = new System.Drawing.Point(3, 2);
        txtExcludedFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        txtExcludedFolder.Name = "txtExcludedFolder";
        txtExcludedFolder.Size = new System.Drawing.Size(1188, 23);
        txtExcludedFolder.TabIndex = 30;
        txtExcludedFolder.KeyPress += txtExcludedFolder_KeyPress;
        // 
        // listExcludedFolders
        // 
        listExcludedFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        listExcludedFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader8 });
        listExcludedFolders.ContextMenuStrip = ctxExcludedFolders;
        listExcludedFolders.Dock = System.Windows.Forms.DockStyle.Bottom;
        listExcludedFolders.FullRowSelect = true;
        listExcludedFolders.GridLines = true;
        listExcludedFolders.Location = new System.Drawing.Point(3, 35);
        listExcludedFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        listExcludedFolders.Name = "listExcludedFolders";
        listExcludedFolders.Scrollable = false;
        listExcludedFolders.Size = new System.Drawing.Size(1188, 725);
        listExcludedFolders.TabIndex = 29;
        listExcludedFolders.UseCompatibleStateImageBehavior = false;
        listExcludedFolders.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader8
        // 
        columnHeader8.Name = "columnHeader8";
        columnHeader8.Text = "Folders";
        columnHeader8.Width = 900;
        // 
        // ctxExcludedFolders
        // 
        ctxExcludedFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
        ctxExcludedFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { deleteToolStripMenuItem });
        ctxExcludedFolders.Name = "ctxExcludedFolders";
        ctxExcludedFolders.Size = new System.Drawing.Size(108, 26);
        ctxExcludedFolders.Opening += ctxExcludedFolders_Opening;
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
        pageModExclusions.Size = new System.Drawing.Size(1194, 762);
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
        splitContainer1.Size = new System.Drawing.Size(1188, 758);
        splitContainer1.SplitterDistance = 659;
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
        lstModList.Size = new System.Drawing.Size(659, 735);
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
        txtModsLocation.Size = new System.Drawing.Size(659, 23);
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
        splitContainer2.Size = new System.Drawing.Size(525, 758);
        splitContainer2.SplitterDistance = 346;
        splitContainer2.SplitterWidth = 3;
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
        listView1.Size = new System.Drawing.Size(525, 346);
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
        listView2.Size = new System.Drawing.Size(525, 409);
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
        // FrmMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1202, 812);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip1);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "SkyMapper v1.0b";
        FormClosing += FrmMain_FormClosing;
        Load += FrmMain_LoadAsync;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabProcessing.ResumeLayout(false);
        ctxProcessing.ResumeLayout(false);
        tabSettings.ResumeLayout(false);
        tabSettings.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackHeightIntensity).EndInit();
        ((System.ComponentModel.ISupportInitialize)numThreadsCount).EndInit();
        pageFolderExclusions.ResumeLayout(false);
        pageFolderExclusions.PerformLayout();
        ctxExcludedFolders.ResumeLayout(false);
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
    private SplitContainer splitContainer1;
    private ListView lstModList;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private TextBox txtModsLocation;
    private SplitContainer splitContainer2;
    private ListView listView1;
    private ColumnHeader columnHeader6;
    private ListView listView2;
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
    private TabPage pageFolderExclusions;
    private System.Windows.Forms.ListView listExcludedFolders;
    private ColumnHeader columnHeader8;
    private System.Windows.Forms.TextBox txtExcludedFolder;
    private ContextMenuStrip ctxExcludedFolders;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private Button btnSaveSettings;
    private Button btnReset;
    private ToolStripSeparator toolStripMenuItem12;
    private ToolStripMenuItem copyFilePathMenuItem;
    private ToolStripMenuItem excludeFolderMenuItem;
    private ToolStripStatusLabel stripTimer;
    private System.Windows.Forms.Timer timerProcess;
    private ToolStripMenuItem filePathToolStripMenuItem;
    private ToolStripMenuItem statusToolStripMenuItem;
    private ToolStripMenuItem hashToolStripMenuItem;
    private ToolStripMenuItem lineToolStripMenuItem;
    private System.Windows.Forms.CheckBox checkRemoveOutput;
    private System.Windows.Forms.CheckBox checkKeepOutputInSync;
}