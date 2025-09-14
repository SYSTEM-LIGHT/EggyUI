# EggyUI

**简体中文** | [English](README_en-us.md)

If you find GitHub access too slow within mainland China, you can check the project's page on Gitee: [https://gitee.com/system-light/EggyUI/tree/master/](https://gitee.com/system-light/EggyUI/tree/master/)

## 🎮 Project Introduction
EggyUI is a customization theme pack specifically designed for the Windows desktop, drawing inspiration from the NetEase game "Eggy Party".

> [!NOTE]
> **Important Notes**
> 1.  **Platform Limitation**: It only works on the Windows desktop; mobile phones or other operating systems cannot use it.
> 2.  **Fan Creation**: This project is a fan-made derivative work and must not be used for commercial purposes.
> 3.  **Non-Commercial Nature**: Want to use it for profit? Not allowed. This includes selling it for a fee, bundling it with commercial software, profiting from ads, or including it in paid services – none of these are permitted.
> 4.  **Asset Sources**: During development, we paid special attention to:
>     *   Not using any assets from unpacking/disassembling "Eggy Party".
>     *   All visual elements were obtained from legal channels (such as in-game screenshots, official promotional images).
>     *   Elements that look similar were redrawn by us to recreate the game's UI style.
> 5.  **Trademarks and Attribution**:
>     *   This project is not related to Microsoft Corporation; it is an independently developed third-party theme customization pack.
>     *   Windows is a registered trademark of Microsoft in the U.S. and other countries.
>     *   This is merely an unofficial visual modification on the Windows system and does not represent the views or products of Microsoft officially.
>     *   "Eggy Party" is a registered trademark of NetEase Games. EggyUI is not affiliated with NetEase officially.

## 🌟 About EggyUI
*   **Nature**: Non-profit fan creation (simply put, it's a Windows desktop customization pack).
*   **Developer**: Initiated by [BSOD-MEMZ](https://github.com/BSOD-MEMZ) (Bilibili homepage: [https://space.bilibili.com/1975308950](https://space.bilibili.com/1975308950)) and maintained by a passionate community of developers.
*   **Positioning**: A feature-rich Windows desktop personalization theme pack.
*   **Copyright and Trademark Statement**:
    *   It is a derivative work based on the UI style of NetEase's "Eggy Party". The original game assets' copyright belongs to NetEase.
    *   Assets in the pack are either our own remakes or obtained legally; there are absolutely no unpacked game assets.
    *   The Windows operating system and its related trademarks (such as names, logos) belong to Microsoft. The EggyUI team has no affiliation, sponsorship, or official endorsement from Microsoft.

## ✨ EggyUI Development History

*   **Origin and Early Versions (2024)**:
    *   The project started in April 2024. Developer BSOD-MEMZ was working on a Shell interface for an "Eggy Party"-style Windows PE maintenance system (called EggyOS). Although this system was never released publicly, it became the foundation for EggyUI.
    *   On July 22, 2024, BSOD-MEMZ released EggyUI 1.0, which initially only supported Win11. Later, other developers created a Win10 version.
    *   On August 8, 2024, EggyUI 2.0 was released as a standalone installer, but the installation process was too cumbersome and criticized by many. On January 25, 2025, the 2.5 version system image was released, adding acrylic effects and optimizing Rainmeter components.

*   **The Tribulations of 3.0 and Community Effort (March-May 2025)**:
    *   **Mid-March 2025**: As EggyUI 3.0 development neared completion, **the original project communication group was unexpectedly disbanded, resulting in the loss of critical installer and resource files**, stalling development. Core developer Sylphy was一度情绪低落 (once felt down) due to losing access to the private repository.
    *   **Community Member Saves the Day**: Developer **SYSTEM-LIGHT** re-uploaded their locally saved development backup files to a new group and took over group management, **saving the project** and preserving the groundwork for the final release of version 3.0.
    *   **Early May 2025**: Core developer **Sylphy** left the project due to personal reasons. Member "神不搞我搞" (formerly "光光猫猫") **unilaterally announced the project team was "temporarily dissolved"**, sparking strong opposition within the team.
    *   **Not Actually Dissolved**: Project founder **BSOD-MEMZ** and other core members (like **red.blue.light**, **SYSTEM-LIGHT**) **strongly opposed the dissolution decision**. After a brief period of chaos, development continued, pushed forward by the remaining members.

*   **The Fleeting Appearance of the Eggy Desktop Pet**:
    *   EggyUI 3.0 originally included an Eggy desktop pet, created by Sylphy and Red.Blue.Light using Python. It was intended to be an AI-powered interactive assistant.
    *   However, it was removed by version 3.5, primarily because:
        *   The AI functionality became unusable, and core developer Sylphy had left the team.
        *   This part of the code was never open-sourced.
        *   Subsequent maintenance was too burdensome. Although it couldn't be continued, it represented an interesting attempt at an interactive desktop experience.

*   **The Innovation and Release of 3.5 (July 2025)**:
    *   Driven primarily by **SYSTEM-LIGHT**, the project shifted towards a more stable technical architecture and deployment method.
    *   Core components were **rewritten using the .NET framework**, replacing parts previously written in Easy Language, significantly improving performance, compatibility, and security.
    *   A new **Windows system image + unattended automatic deployment** installation method was adopted, providing a more complete experience.
    *   **On July 22, 2025** (the project's first anniversary), the EggyUI 3.5 system image was officially released. Its promotional and testing videos were published by **SYSTEM-LIGHT** under the Bilibili account "一只野生的蛋小绿_Eggy" and successfully attracted significant attention.

*   **Unrealized Concepts**:
    *   **GloPM**: A resource sharing center designed by Sylphy, which was not implemented due to maintenance risks and technical complexity.
    *   **Font Strategy**: Learning from previous versions, system fonts are no longer globally replaced; theme fonts are only used in specific components, ensuring system stability.

## 🤝 Contributors

Thanks to all developers who contributed to the EggyUI project, especially the following core members:
*   **[BSOD-MEMZ](https://github.com/BSOD-MEMZ)** - Project Founder
*   **SYSTEM-LIGHT ([SYSTEM-LIGHT](https://github.com/SYSTEM-LIGHT))** - Core developer and main driver behind EggyUI 3.5, resolved the 3.0 crisis and completed the 3.5 release
*   **Sylphy** - Early core developer, designed advanced features like the AI desktop pet
*   **red.blue.light** - Core developer, participated in the development of multiple components
*   **20年冬 (爱苏璇儿)** - Testing and Promotion
*   **神不搞我搞 (formerly 光光猫猫, 宣传蛋)** - Early planning and promotion

(This list is organized by the nature of contribution. Thanks to all members who participated!)

## ⚙️ Major Innovations in EggyUI 3.5

*   **Basic Information**:
    *   Non-commercial and free, for personal use only, not for commercial use.
    *   All materials are compliant; interface elements are remade based on officially published assets.

*   **Technical Architecture Upgrade**:
    *   Core components were partially rewritten using the .NET framework (replacing parts previously in Easy Language), bringing several benefits:
        *   Stronger system compatibility.
        *   Performance improved by over 40%, with noticeably faster operation response.
        *   Better security and stability, easier maintenance.
        *   Reduced risk of memory leaks.

*   **Major Change in Installation Mode**:
    *   Uses a brand new Windows system installation with unattended automatic deployment technology.
    *   To see a release demonstration, there's a video on Bilibili: [蛋仔派对风格定制Win11——Eggy UI 3.5体验](https://www.bilibili.com/video/BV1kbgGz7Em1) (Eggy Party Style Custom Win11 – Eggy UI 3.5 Experience)
    *   There's also a physical machine demo by [0xc0000022](https://space.bilibili.com/1092500907): [Eggy UI 3.5实体机开箱体验](https://www.bilibili.com/video/BV13w8nzqE4V) (Eggy UI 3.5 Physical Machine Unboxing Experience)

*   **Release Notes and Clarifications**:
    *   Claims of an "image leak" are pure rumors, actually stemming from internal team communication issues.
    *   Actual release timeline was:
        *   Review video released on July 21, 2025 (eve of the anniversary).
        *   Image officially released on July 22, coinciding with the anniversary celebration.
    *   Regarding compatibility:
        *   System modifications have undergone strict testing.
        *   Very rare special circumstances (e.g., system drive letter being X:) might cause issues.
        *   For uncommon issues like Start Menu malfunctions, we are collecting feedback for prompt improvements.

*   **Some Recommendations**:
    *   ⚠️ Sincere advice: It's best to use this customization theme on a clean, genuine Windows system.
    *   💡 We are developing a safer standalone installer aimed at not modifying core system files.
    *   The currently provided system image solution carries higher risks than typical desktop customization operations.

*   **Breakthrough Achievements**:
    *   Previous compatibility issues (e.g., network configuration failures) have been completely resolved.
    *   Component performance has also been significantly enhanced.

## 💡 Summary
> [!WARNING]
> **Reiterating**: We strongly recommend prioritizing the use of these customization components via standard installation methods on a clean, genuine Windows system. Using modified system images pre-installed with themes may carry instability risks, for which you must take responsibility. The EggyUI 3.5 standalone installer designed specifically for genuine systems is in active development; stay tuned for后续更新 (follow-up updates).

EggyUI is a theme pack for customizing the Windows desktop, non-commercial in nature, created by fans. Version 3.5 adopted a new system-level deployment method and rewrote components using .NET, significantly improving compatibility and stability.

**Important Reiteration**:
🔒 **This is a fan creation for "Eggy Party"**:
*   Permanently free and absolutely not permitted for commercial use.
*   Does not use any unpacked game assets; everything is remade or obtained legally.
*   Commercial use violates the license terms.

🔒 **Legal and Trademark Statement**:
*   EggyUI is not affiliated with Microsoft or NetEase.
*   Windows is a registered trademark of Microsoft. "Eggy Party" is a registered trademark of NetEase.
*   This is merely an unofficial visual modification on the Windows system, intended to allow for more personalized use.

![Eggy UI 3.5 Promotional Image](Promo.png "Eggy UI 3.5")