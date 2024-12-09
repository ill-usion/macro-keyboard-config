namespace MacroKeyboardConfig
{
	public enum MacroType : byte
	{
		KEY, TEXT
	}

	public interface ProgrammableMacro
	{
		MacroType GetType();
		int GetIndex();
	}
}
