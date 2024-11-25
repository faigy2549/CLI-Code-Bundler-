# CodeBundler CLI

A powerful command-line tool for efficient code management and bundling.

**Key Features:**

  * **Bundle Files:** Combine multiple code files into a single output file.
  * **Response Files:** Manage configurations easily with `.rsp` files.
  * **Flexible Sorting:** Sort files by filename or type.
  * **Customizable Output:** Include or exclude notes, remove empty lines, specify author information.
  * **Global Accessibility:** Run commands from any directory.

**Installation**

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yourusername/CLI-CodeBundler.git]
    cd codebundler-cli
    ```
2.  **Build the project:**
    ```bash
    dotnet build
    ```
3.  **Install the CLI globally:**
    ```bash
    dotnet publish -c Release -o C:\Tools\CodeBundler
    ```
    Add `C:\Tools\CodeBundler` to your system's PATH.

**Usage**

1.  **Bundling Files:**

    ```bash
    codeBundler bundle @bundle.rsp
    ```

      - `@bundle.rsp`: Response file with configuration options.

2.  **Creating a Response File:**

    ```bash
    codeBundler create-rsp
    ```

    Follow the prompts to configure options.

**Example Response File:**
-l cs
-o bundled_code.txt
-n false
-s filename
-r true
-a John Doe
**Available Options:**

  * `-l <language>`: Specify language (e.g., `cs`, `js`, `all`).
  * `-o <output>`: Specify output file path (default: `bundle.txt`).
  * `-n`: Include notes (true/false).
  * `-s`: Sort by filename or type.
  * `-r`: Remove empty lines (true/false).
  * `-a <author>`: Add author information.

**Development**

  * **Prerequisites:** .NET SDK
  * **Building:**
    ```bash
    dotnet build
    ```
  * **Running Locally:**
    ```bash
    dotnet run <command>
    ```
    (e.g., `dotnet run create-rsp`)

**License**
This project is licensed under the MIT License.
