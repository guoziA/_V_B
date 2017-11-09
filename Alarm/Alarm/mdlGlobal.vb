Module mdlGlobal
    Public Const ALARM_Aproching = "aproching"
    Public Const ALARM_Passing = "passing"
    Public Const ALARM_Passed = "passed"
    Public Const ALARM_Missed = "missed"

    Public Const TIME_Future = 1
    Public Const TIME_Now = 0
    Public Const TIME_Passed = -1

    Public time_PASSING_Index As Integer
    Public time_APROCHING_Index As Integer

    Public isPlaying As Boolean
    Public isComming As Boolean

End Module
