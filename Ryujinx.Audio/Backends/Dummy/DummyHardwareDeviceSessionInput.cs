using Ryujinx.Audio.Common;
using Ryujinx.Audio.Integration;
using Ryujinx.Memory;
using System;

namespace Ryujinx.Audio.Backends.Dummy
{
    class DummyHardwareDeviceSessionInput : IHardwareDeviceSession
    {
        private float _volume;
        private IHardwareDeviceDriver _manager;
        private IVirtualMemoryManager _memoryManager;

        public DummyHardwareDeviceSessionInput(IHardwareDeviceDriver manager, IVirtualMemoryManager memoryManager, SampleFormat requestedSampleFormat, uint requestedSampleRate, uint requestedChannelCount)
        {
            _volume = 1.0f;
            _manager = manager;
            _memoryManager = memoryManager;
        }

        public void Dispose()
        {
            // Nothing to do.
        }

        public ulong GetPlayedSampleCount()
        {
            // Not implemented for input.
            throw new NotSupportedException();
        }

        public float GetVolume()
        {
            return _volume;
        }

        public void PrepareToClose() {
            throw new NotSupportedException();
        }

        public void QueueBuffer(AudioBuffer buffer)
        {
            _memoryManager.Fill(buffer.DataPointer, buffer.DataSize, 0);

            _manager.GetUpdateRequiredEvent().Set();
        }

        public bool RegisterBuffer(AudioBuffer buffer)
        {
            return buffer.DataPointer != 0;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
        }

        public void Start() { }

        public void Stop() { }

        public void UnregisterBuffer(AudioBuffer buffer) { }

        public bool WasBufferFullyConsumed(AudioBuffer buffer)
        {
            return true;
        }
    }
}