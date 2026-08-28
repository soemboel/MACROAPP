using MacroApp.Models;
using MacroApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MacroApp
{
    public partial class Form1 : Form
    {
        private readonly MacroPlayer macroPlayer;
        private readonly HotkeyService hotkeyService;
        private readonly MacroRecorder macroRecorder;

        private List<MacroAction> actions;

        public Form1()
        {
            InitializeComponent();

            macroPlayer = new MacroPlayer();
            hotkeyService = new HotkeyService();

            actions = new List<MacroAction>();
            macroRecorder = new MacroRecorder(actions);
            macroRecorder.ActionRecorded += MacroRecorder_ActionRecorded;
        }

        private void StartMacro()
        {
            if (actions.Count == 0)
                return;

            macroPlayer.Play(
                actions,
                RepeatCB.Checked);

            StatusLB.Text = "Running";
        }

        private void StopMacro()
        {
            macroPlayer.Stop();

            StatusLB.Text = "Stopped";
        }

        private void StartRecording()
        {
            if (macroRecorder.IsRecording)
                return;

            if (macroPlayer.IsRunning)
                StopMacro();

            actions.Clear();
            RefreshActionList();

            try
            {
                macroRecorder.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Macro App",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            SetRecordingUi(true);
            StatusLB.Text = "Recording...";
        }

        private void StopRecording()
        {
            if (!macroRecorder.IsRecording)
                return;

            macroRecorder.Stop();
            SetRecordingUi(false);
            RefreshActionList();
            StatusLB.Text = "Stopped";
        }

        private void SetRecordingUi(bool isRecording)
        {
            RecordBTN.Enabled = !isRecording;
            StopRecordBTN.Enabled = isRecording;
            StartBTN.Enabled = !isRecording;
            AddKeyBTN.Enabled = !isRecording;
            AddClickBTN.Enabled = !isRecording;
            AddMoveBTN.Enabled = !isRecording;
            RemoveBTN.Enabled = !isRecording;

            RecordBTN.BackColor = isRecording
                ? Color.LightCoral
                : SystemColors.Control;
        }

        private void MacroRecorder_ActionRecorded(MacroAction action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<MacroAction>(
                    MacroRecorder_ActionRecorded),
                    action);

                return;
            }

            RefreshActionList();
        }

        private void RefreshActionList()
        {
            ActionList.Items.Clear();

            for (int i = 0; i < actions.Count; i++)
            {
                MacroAction action = actions[i];
                string parameter = GetActionParameter(action);

                ListViewItem item =
                    new ListViewItem((i + 1).ToString());

                item.SubItems.Add(action.Type.ToString());
                item.SubItems.Add(parameter);
                item.SubItems.Add(action.Delay.ToString());

                ActionList.Items.Add(item);
            }

            if (ActionList.Items.Count > 0)
            {
                ActionList.EnsureVisible(
                    ActionList.Items.Count - 1);
            }
        }

        private static string GetActionParameter(MacroAction action)
        {
            switch (action.Type)
            {
                case MacroActionType.MouseMove:
                case MacroActionType.MouseLeftDown:
                case MacroActionType.MouseLeftUp:
                case MacroActionType.MouseRightDown:
                case MacroActionType.MouseRightUp:
                case MacroActionType.MouseMiddleDown:
                case MacroActionType.MouseMiddleUp:
                case MacroActionType.MouseWheel:
                    return $"{action.X},{action.Y}";

                default:
                    return action.Parameter ?? string.Empty;
            }
        }

        private void SetupActionList()
        {
            ActionList.View = View.Details;
            ActionList.FullRowSelect = true;
            ActionList.GridLines = true;

            ActionList.Columns.Add("#", 40);
            ActionList.Columns.Add("Type", 140);
            ActionList.Columns.Add("Parameter", 240);
            ActionList.Columns.Add("Delay (ms)", 80);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();

                if (id == HotkeyService.START_HOTKEY)
                {
                    StartMacro();
                }
                else if (id == HotkeyService.STOP_HOTKEY)
                {
                    StopMacro();
                }
                else if (id == HotkeyService.RECORD_START_HOTKEY)
                {
                    StartRecording();
                }
                else if (id == HotkeyService.RECORD_STOP_HOTKEY)
                {
                    StopRecording();
                }
            }

            base.WndProc(ref m);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            macroRecorder.Dispose();

            hotkeyService.Unregister(
                this.Handle,
                HotkeyService.START_HOTKEY);

            hotkeyService.Unregister(
                this.Handle,
                HotkeyService.STOP_HOTKEY);

            hotkeyService.Unregister(
                this.Handle,
                HotkeyService.RECORD_START_HOTKEY);

            hotkeyService.Unregister(
                this.Handle,
                HotkeyService.RECORD_STOP_HOTKEY);

            macroPlayer.Stop();

            base.OnFormClosed(e);
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            if (actions.Count == 0)
            {
                MessageBox.Show(
                    "Belum ada action di dalam macro.",
                    "Macro App",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            StartMacro();
        }

        private void StopBTN_Click(object sender, EventArgs e)
        {
            StopMacro();
        }

        private void RecordBTN_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void StopRecordBTN_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void AddKeyBTN_Click(object sender, EventArgs e)
        {
            MacroAction action = new MacroAction
            {
                Type = MacroActionType.KeyPress,
                Parameter = "A",
                Delay = (int)numDelay.Value
            };

            actions.Add(action);

            RefreshActionList();
        }

        private void AddClickBTN_Click(object sender, EventArgs e)
        {
            Point position = Cursor.Position;

            MacroAction action = new MacroAction
            {
                Type = MacroActionType.MouseClick,
                Parameter = "Left",
                X = position.X,
                Y = position.Y,
                Delay = (int)numDelay.Value
            };

            actions.Add(action);

            RefreshActionList();
        }

        private void AddMoveBTN_Click(object sender, EventArgs e)
        {
            Point position = Cursor.Position;

            MacroAction action = new MacroAction
            {
                Type = MacroActionType.MouseMove,
                X = position.X,
                Y = position.Y,
                Parameter =
                    $"{position.X},{position.Y}",
                Delay = (int)numDelay.Value
            };

            actions.Add(action);

            RefreshActionList();
        }

        private void RemoveBTN_Click(object sender, EventArgs e)
        {
            if (ActionList.SelectedIndices.Count == 0)
                return;

            int index =
                ActionList.SelectedIndices[0];

            actions.RemoveAt(index);

            RefreshActionList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupActionList();
            SetRecordingUi(false);

            hotkeyService.Register(
                this.Handle,
                HotkeyService.START_HOTKEY,
                Keys.F6);

            hotkeyService.Register(
                this.Handle,
                HotkeyService.STOP_HOTKEY,
                Keys.F7);

            hotkeyService.Register(
                this.Handle,
                HotkeyService.RECORD_START_HOTKEY,
                Keys.F10);

            hotkeyService.Register(
                this.Handle,
                HotkeyService.RECORD_STOP_HOTKEY,
                Keys.F11);
        }
    }
}
