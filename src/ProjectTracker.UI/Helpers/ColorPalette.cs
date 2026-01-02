using System.Drawing;

namespace ProjectTracker.UI.Helpers
{
    /// <summary>
    /// Modern Slate Blue Theme - Global Color Palette
    /// Provides centralized color management for consistent theming across the application.
    /// </summary>
    public static class ColorPalette
    {
        #region Background Colors
        
        /// <summary>
        /// Main background color - Deep Navy (#1A1F26) - Softened
        /// Used for: Form backgrounds, main containers
        /// </summary>
        public static readonly Color BackgroundDeepNavy = Color.FromArgb(26, 31, 38);

        /// <summary>
        /// Secondary background - Slate Dark (#242B3D) - Softened
        /// Used for: Panels, cards, sidebar
        /// </summary>
        public static readonly Color BackgroundSlateDark = Color.FromArgb(36, 43, 61);

        /// <summary>
        /// Tertiary background - Slate Medium (#1E2A3A)
        /// Used for: Modal dialogs, elevated panels
        /// </summary>
        public static readonly Color BackgroundSlateMedium = Color.FromArgb(30, 42, 58);

        /// <summary>
        /// Input background - Slate Light (#2A3F5F)
        /// Used for: TextBox, ComboBox, input controls
        /// </summary>
        public static readonly Color BackgroundSlateLight = Color.FromArgb(42, 63, 95);

        /// <summary>
        /// Border color - Slate Border (#334155)
        /// Used for: Borders, separators, dividers
        /// </summary>
        public static readonly Color BorderSlate = Color.FromArgb(51, 65, 85);

        #endregion

        #region Accent Colors

        /// <summary>
        /// Primary accent - Soft Blue (#5B8DEF) - Reduced brightness
        /// Used for: Primary buttons, CTAs, active states
        /// </summary>
        public static readonly Color AccentRoyalBlue = Color.FromArgb(91, 141, 239);

        /// <summary>
        /// Hover accent - Soft Sky (#7BA8F7) - Muted hover
        /// Used for: Button hover states
        /// </summary>
        public static readonly Color AccentSkyBlue = Color.FromArgb(123, 168, 247);

        /// <summary>
        /// Link accent - Muted Blue (#8ABAFC) - Softer links
        /// Used for: Hyperlinks, active tabs
        /// </summary>
        public static readonly Color AccentLightBlue = Color.FromArgb(138, 186, 252);

        /// <summary>
        /// Active/Pressed accent - Soft Glow (#4A6FD4) - Balanced active state
        /// Used for: Button pressed/active state
        /// </summary>
        public static readonly Color AccentBlueGlow = Color.FromArgb(74, 111, 212);

        #endregion

        #region Semantic Colors - Success

        /// <summary>
        /// Success primary - Green (#10B981)
        /// Used for: Completed tasks, success messages, positive trends
        /// </summary>
        public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);

        /// <summary>
        /// Success light - Light Green (#22C55E)
        /// Used for: Positive percentage changes, growth indicators
        /// </summary>
        public static readonly Color SuccessLight = Color.FromArgb(34, 197, 94);

        #endregion

        #region Semantic Colors - Warning

        /// <summary>
        /// Warning primary - Orange (#F97316)
        /// Used for: Pending tasks, warnings, caution indicators
        /// </summary>
        public static readonly Color WarningOrange = Color.FromArgb(249, 115, 22);

        /// <summary>
        /// Warning secondary - Amber (#FBB034)
        /// Used for: Progress bars (mid-range), in-progress states
        /// </summary>
        public static readonly Color WarningAmber = Color.FromArgb(251, 176, 52);

        #endregion

        #region Semantic Colors - Danger

        /// <summary>
        /// Danger primary - Red (#EF4444)
        /// Used for: Errors, cancelled items, delete actions
        /// </summary>
        public static readonly Color DangerRed = Color.FromArgb(239, 68, 68);

        /// <summary>
        /// Danger dark - Dark Red (#DC2626)
        /// Used for: Negative percentage changes, decline indicators
        /// </summary>
        public static readonly Color DangerDark = Color.FromArgb(220, 38, 38);

        #endregion

        #region Category Accent Colors

        /// <summary>
        /// Category color - Purple (#A855F7)
        /// Used for: Backend/Dev category, purple-themed items
        /// </summary>
        public static readonly Color CategoryPurple = Color.FromArgb(168, 85, 247);

        /// <summary>
        /// Category color - Magenta (#D946EF)
        /// Used for: Special categories, magenta-themed items
        /// </summary>
        public static readonly Color CategoryMagenta = Color.FromArgb(217, 70, 239);

        /// <summary>
        /// Category color - Cyan (#06B6D4)
        /// Used for: Support category, cyan-themed items
        /// </summary>
        public static readonly Color CategoryCyan = Color.FromArgb(6, 182, 212);

        /// <summary>
        /// Category color - Blue (#60A5FA)
        /// Used for: Low priority tasks, blue-themed categories
        /// </summary>
        public static readonly Color CategoryBlue = Color.FromArgb(96, 165, 250);

        /// <summary>
        /// Category color - Teal (Alias for CategoryCyan)
        /// Used for: Teal-themed categories, consistent naming
        /// </summary>
        public static readonly Color CategoryTeal = CategoryCyan;

        #endregion

        #region Text Colors

        /// <summary>
        /// Primary text - Off White (#F8FAFC)
        /// Used for: Headings, important text (AAA contrast)
        /// </summary>
        public static readonly Color TextPrimary = Color.FromArgb(248, 250, 252);

        /// <summary>
        /// Secondary text - Light Gray (#CBD5E1)
        /// Used for: Descriptions, labels (AA contrast)
        /// </summary>
        public static readonly Color TextSecondary = Color.FromArgb(203, 213, 225);

        /// <summary>
        /// Tertiary text - Medium Gray (#94A3B8)
        /// Used for: Placeholders, less important text
        /// </summary>
        public static readonly Color TextTertiary = Color.FromArgb(148, 163, 184);

        /// <summary>
        /// Muted text - Dark Gray (#64748B)
        /// Used for: Disabled controls, subtle information
        /// </summary>
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);

        /// <summary>
        /// Disabled text (Alias for TextMuted)
        /// Used for: Disabled/inactive UI elements  
        /// </summary>
        public static readonly Color TextDisabled = TextMuted;

        #endregion

        #region Legacy Compatibility (Deprecated)

        /// <summary>
        /// [DEPRECATED] Use BackgroundDeepNavy instead
        /// </summary>
        [System.Obsolete("Use BackgroundDeepNavy instead", false)]
        public static readonly Color BackgroundMain = BackgroundDeepNavy;

        /// <summary>
        /// [DEPRECATED] Use BackgroundSlateDark instead
        /// </summary>
        [System.Obsolete("Use BackgroundSlateDark instead", false)]
        public static readonly Color PanelBackground = BackgroundSlateDark;

        /// <summary>
        /// [DEPRECATED] Use AccentRoyalBlue instead (changed from orange to blue)
        /// </summary>
        [System.Obsolete("Orange accent replaced with blue theme - use AccentRoyalBlue", false)]
        public static readonly Color OrangeAccent = AccentRoyalBlue;

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets progress bar color based on completion percentage
        /// </summary>
        /// <param name="percentage">Completion percentage (0-100)</param>
        /// <returns>Appropriate color for the percentage</returns>
        public static Color GetProgressColor(int percentage)
        {
            if (percentage < 30)
                return DangerRed;      // 0-30%: Red
            else if (percentage < 70)
                return WarningAmber;   // 30-70%: Orange
            else
                return SuccessGreen;   // 70-100%: Green
        }

        /// <summary>
        /// Gets status color for ProjectStatus enum
        /// </summary>
        public static Color GetProjectStatusColor(Core.Enums.ProjectStatus status)
        {
            return status switch
            {
                Core.Enums.ProjectStatus.Completed => SuccessGreen,
                Core.Enums.ProjectStatus.Active => WarningAmber,
                Core.Enums.ProjectStatus.Cancelled => DangerRed,
                Core.Enums.ProjectStatus.OnHold => TextMuted,
                _ => AccentRoyalBlue // Planning/Default
            };
        }

        /// <summary>
        /// Gets priority color for Priority enum
        /// </summary>
        public static Color GetPriorityColor(Core.Enums.Priority priority)
        {
            return priority switch
            {
                Core.Enums.Priority.Critical => DangerRed,
                Core.Enums.Priority.High => WarningOrange,
                Core.Enums.Priority.Medium => SuccessGreen,
                Core.Enums.Priority.Low => TextMuted,
                _ => TextSecondary
            };
        }

        /// <summary>
        /// Creates a semi-transparent version of a color
        /// </summary>
        /// <param name="color">Base color</param>
        /// <param name="opacity">Opacity (0-255)</param>
        /// <returns>Color with specified opacity</returns>
        public static Color WithOpacity(Color color, int opacity)
        {
            return Color.FromArgb(opacity, color.R, color.G, color.B);
        }

        #endregion
    }
}
